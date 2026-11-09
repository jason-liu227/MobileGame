using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
