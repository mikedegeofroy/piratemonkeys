# -------------------------------------
# Stage 1: Unity WebGL Build
# -------------------------------------
FROM unityci/editor:ubuntu-6000.0.46f1-webgl-3.1.0 as builder

WORKDIR /project

# Accept the license file as a build argument
ARG UNITY_LICENSE

# Set up Unity license directory and save the license file
RUN mkdir -p /root/.config/unity3d && \
    echo "$UNITY_LICENSE" > /root/.config/unity3d/Unity_v202x.x.x.ulf

# Copy the entire Unity project into the build container
COPY . .

# Build the WebGL version of the project
RUN unity-editor \
    -batchmode \
    -nographics \
    -silent-crashes \
    -quit \
    -logFile /dev/stdout \
    -projectPath . \
    -buildTarget WebGL \
    -executeMethod BuildScript.BuildClient

# -------------------------------------
# Stage 2: NGINX for Hosting
# -------------------------------------
FROM nginx:alpine

# Clean default content
RUN rm -rf /usr/share/nginx/html/*

# Copy built WebGL content from previous stage
COPY --from=builder /project/Builds/WebGL/ /usr/share/nginx/html/

# Expose web port
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
