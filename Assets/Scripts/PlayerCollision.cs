
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCollision : MonoBehaviour
{
    private bool crashed;

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
}
