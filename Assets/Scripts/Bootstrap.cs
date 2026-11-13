using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;

        DontDestroyOnLoad(gameObject);

        Telemetry.Log(
            "session_start",
            ("app_version", Application.version),
            ("device_model", SystemInfo.deviceModel),
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


