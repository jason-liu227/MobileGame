using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinText;

    [Header("Scoring")]
    [SerializeField] private float startingPointsPerSecond = 10f;
    [SerializeField] private float increaseEverySeconds = 20f;
    [SerializeField] private float rateIncrease = 1f;

    private float elapsedTime;
    private float score;
    private int coins;

    void Start()
    {
        UpdateDisplay();
    }

    void Update()
    {
        if (gameManager == null ||
            gameManager.CurrentState != GameManager.State.Playing)
            return;

        elapsedTime += Time.deltaTime;

        int increases = Mathf.FloorToInt(elapsedTime / increaseEverySeconds);
        float pointsPerSecond =
            startingPointsPerSecond + increases * rateIncrease;

        score += pointsPerSecond * Time.deltaTime;

        UpdateDisplay();
    }

    public void AddCoin()
    {
        coins++;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {Mathf.FloorToInt(score)}";

        if (coinText != null)
            coinText.text = $"Coins: {coins}";
    }
}
