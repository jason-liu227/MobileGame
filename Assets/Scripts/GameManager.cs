using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Playing,
        Paused,
        Won,
        Lost
    }

    public event Action<State> StateChanged;

    public State CurrentState { get; private set; }
    public static State LastResult { get; private set; }

    [Header("Telemetry")]
    [SerializeField] private int levelId = 1;
    [SerializeField] private ScoreManager scoreManager;

    private static int attemptCount;
    private float levelStartTime;
    private int startingCoins;
    private int startingCoinsCollected;
    private bool levelStarted;

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        attemptCount++;
        levelStarted = true;

        levelStartTime = Time.time;

        startingCoins = Wallet.Instance != null
            ? Wallet.Instance.Coins
            : 0;

        startingCoinsCollected = CoinManager.Instance != null
            ? CoinManager.Instance.CoinsCollected
            : 0;

        SetState(State.Playing);

        Telemetry.Log(
            "level_start",
            ("level_id", levelId),
            ("attempt", attemptCount),
            ("coins", startingCoins)
        );
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.pKey.wasPressedThisFrame)
            PauseGame();

        if (Keyboard.current.rKey.wasPressedThisFrame)
            ResumeGame();
    }

    public void SetState(State newState)
    {
        if (CurrentState == newState)
            return;

        CurrentState = newState;

        Time.timeScale = newState == State.Playing ? 1f : 0f;

        StateChanged?.Invoke(newState);

        if (!levelStarted)
            return;

        if (newState == State.Won || newState == State.Lost)
        {
            float elapsedTime = Time.time - levelStartTime;

            int coinsEarned = CoinManager.Instance != null
                ? (CoinManager.Instance.CoinsCollected -
                   startingCoinsCollected) * 5
                : 0;

            if (newState == State.Won)
            {
                int score = scoreManager != null
                    ? scoreManager.CurrentScore
                    : 0;

                Telemetry.Log(
                    "level_complete",
                    ("level_id", levelId),
                    ("time_s", elapsedTime),
                    ("coins_earned", coinsEarned),
                    ("score", score)
                );
            }
            else
            {
                Telemetry.Log(
                    "level_fail",
                    ("level_id", levelId),
                    ("time_s", elapsedTime),
                    ("cause", "spike"),
                    ("coins_earned", coinsEarned)
                );
            }

            LastResult = newState;
            Time.timeScale = 1f;

            _ = SceneLoader.Instance.Load(
                "ResultScene",
                Application.exitCancellationToken
            );
        }
    }

    public void PauseGame()
    {
        if (CurrentState == State.Playing)
            SetState(State.Paused);
    }

    public void ResumeGame()
    {
        if (CurrentState == State.Paused)
            SetState(State.Playing);
    }

    private void OnApplicationPause(bool paused)
    {
        if (paused)
            PauseGame();
        else
            ResumeGame();
    }

    private void OnApplicationFocus(bool focused)
    {
        if (!focused)
            PauseGame();
        else
            ResumeGame();
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
