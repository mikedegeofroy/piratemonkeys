using UnityEditor;

public static class BuildScript
{
    [MenuItem("Build/Server")]
    public static void BuildServer()
    {
        BuildPipeline.BuildPlayer(
            new BuildPlayerOptions
            {
                scenes = new[] { "Assets/Scenes/Main.unity" },
                locationPathName = "Builds/Linux/Server.x86_64",
                target = BuildTarget.StandaloneLinux64,
                options = BuildOptions.EnableHeadlessMode
            });
    }

    [MenuItem("Build/WebGL")]
    public static void BuildClient()
    {
        BuildPipeline.BuildPlayer(
            new BuildPlayerOptions
            {
                scenes = new[] { "Assets/Scenes/Main.unity" },
                locationPathName = "Builds/WebGL/",
                target = BuildTarget.WebGL
            });
    }
}