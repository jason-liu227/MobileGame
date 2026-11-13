
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text scoreText;

    [Header("Scoring")]
    [SerializeField] private float startingPointsPerSecond = 10f;
    [SerializeField] private float scoreBonusPerUpgrade = 0.10f;

    private float score;

    public int CurrentScore => Mathf.FloorToInt(score);

    private void Start()
    {
        UpdateDisplay();
    }

    private void Update()
    {
        if (gameManager == null ||
            gameManager.CurrentState != GameManager.State.Playing)
            return;

        int level = Wallet.Instance != null
            ? Wallet.Instance.Level
            : 0;

        float multiplier = 1f + level * scoreBonusPerUpgrade;

        score += startingPointsPerSecond * multiplier * Time.deltaTime;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (scoreText != null)
            scoreText.SetText("Score: {0:0}", Mathf.FloorToInt(score));
    }
}
