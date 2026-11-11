using UnityEngine;

public class LaneTimer : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float duration = 120f;

    private float elapsed;
    private bool finished;

    void Update()
    {
        if (gameManager == null || finished)
            return;

        if (gameManager.CurrentState != GameManager.State.Playing)
            return;

        elapsed += Time.deltaTime;

        if (elapsed >= duration)
        {
            finished = true;
            gameManager.SetState(GameManager.State.Won);
        }
    }
}
