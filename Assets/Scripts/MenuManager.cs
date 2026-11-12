using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        _ = SceneLoader.Instance.Load(
            "GameScene",
            Application.exitCancellationToken
        );
    }
}

