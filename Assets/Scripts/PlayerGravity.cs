using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerGravity : MonoBehaviour
{
    public float gravityStrength = 2f;
    public float flipForce = 5f;

    private Rigidbody2D rb;
    private bool gravityUp = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.gravityScale = gravityStrength;
    }

    public void FlipGravity()
    {
        gravityUp = !gravityUp;

        // Reverse gravity
        rb.gravityScale = gravityUp
            ? -gravityStrength
            : gravityStrength;

        // Push the player vertically
        rb.linearVelocity = new Vector2(
            0f,
            gravityUp ? flipForce : -flipForce
        );

        Debug.Log("Gravity flipped! Up = " + gravityUp);
    }
}
