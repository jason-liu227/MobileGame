using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;

        DontDestroyOnLoad(gameObject);

        // Get the first 8 characters of the build GUID.
        string guid = Application.buildGUID;
        string buildId = guid.Length >= 8
            ? guid.Substring(0, 8)
            : guid;

        Telemetry.Log(
            "session_start",
            ("version", Application.version),
            ("build", buildId),
            ("device", SystemInfo.deviceModel),
            ("android", SystemInfo.operatingSystem)
        );
    }

    private async Awaitable Start()
    {
        await SceneLoader.Instance.Load(
            "MenuScene",
            Application.exitCancellationToken
        );
    }
}



