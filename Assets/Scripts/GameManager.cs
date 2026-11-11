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

    private void Start()
    {
        SetState(State.Playing);
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
        bool stateChanged = CurrentState != newState;

        CurrentState = newState;

        Time.timeScale = newState == State.Playing ? 1f : 0f;

        if (stateChanged)
            StateChanged?.Invoke(newState);
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

