using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public float gravityStrength = 2f;
    public float flipForce = 5f;

    private Rigidbody2D rb;
    private bool gravityUp = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void FlipGravity()
    {
        gravityUp = !gravityUp;

        // Reverse gravity
        rb.gravityScale = gravityUp
            ? -gravityStrength
            : gravityStrength;

        // Push the player in the new direction
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            gravityUp ? flipForce : -flipForce
        );

        Debug.Log("Gravity flipped! Up = " + gravityUp);
    }
}