using UnityEngine;
using UnityEngine.InputSystem;

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

    void Update()
    {
        // Mouse click
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            FlipGravity();
        }

        // Space key
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            FlipGravity();
        }
    }

    void FlipGravity()
    {
        gravityUp = !gravityUp;

        // Reverse gravity
        rb.gravityScale = gravityUp
            ? -gravityStrength
            : gravityStrength;

        // Give the player a push in the new direction
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            gravityUp ? flipForce : -flipForce
        );

        Debug.Log("Gravity flipped! Up = " + gravityUp);
    }
}