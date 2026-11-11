using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;

    private void Start()
    {
        if (resultText != null)
        {
            resultText.text = GameManager.LastResult == GameManager.State.Won
                ? "YOU WIN!"
                : "GAME OVER";
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
}
