using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 

public class PlayerCollision : MonoBehaviour
{
    private bool crashed;
    [SerializeField] private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (crashed || !other.CompareTag("Obstacle"))
            return;

        crashed = true;

        Debug.Log("Player hit an obstacle!");

        // Temporary crash feedback.
        // Later we can connect this to Game Over UI.
        GetComponent<SpriteRenderer>().color = Color.red;

        enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (gameManager != null)
            {
                gameManager.SetState(GameManager.State.Lost);
            }
        }
    }
}
