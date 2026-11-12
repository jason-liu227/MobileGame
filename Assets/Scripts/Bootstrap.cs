using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);
    }

    private async Awaitable Start()
    {
        await SceneLoader.Instance.Load(
            "MenuScene",
            Application.exitCancellationToken
        );
    }
}

