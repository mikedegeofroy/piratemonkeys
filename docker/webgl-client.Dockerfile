# -------------------------------------
# Stage 1: Unity WebGL Build
# -------------------------------------
FROM unityci/editor:2022.3.11f1-webgl-1.0.1 as builder

WORKDIR /project

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
