using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private bool crashed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (crashed || !other.CompareTag("Obstacle"))
            return;

        crashed = true;

        Debug.Log("Player hit an obstacle!");

        // Crash feedback
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null)
            sprite.color = Color.red;

        // Trigger lose state
        if (gameManager != null)
        {
            Debug.Log("Setting game state to Lost");
            gameManager.SetState(GameManager.State.Lost);
        }
        else
        {
            Debug.LogError("PlayerCollision: GameManager is not assigned!");
        }

        enabled = false;
    }
}