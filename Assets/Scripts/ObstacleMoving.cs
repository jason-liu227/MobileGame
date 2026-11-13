using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedIncreasePerUpgrade = 0.5f;

    void Update()
    {
        int level = Wallet.Instance != null
            ? Wallet.Instance.Level
            : 0;

        float currentSpeed = speed + level * speedIncreasePerUpgrade;

        transform.position += Vector3.left * currentSpeed * Time.deltaTime;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
