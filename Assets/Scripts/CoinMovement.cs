using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -12f)
            GetComponent<CoinPickup>().ReturnToPool();
    }

}
