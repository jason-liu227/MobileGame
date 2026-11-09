
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private GameObject obstaclePrefab;

    [Header("Track")]
    [SerializeField] private float topY = 3.5f;
    [SerializeField] private float bottomY = -3.5f;

    [Header("Spawning")]
    [SerializeField] private float spawnAhead = 22f;
    [SerializeField] private float despawnBehind = 12f;
    [SerializeField] private float minSpacing = 7f;
    [SerializeField] private float maxSpacing = 11f;    
    [SerializeField] private float spawnInterval = 1.8f;

    [Header("Pooling")]
    [SerializeField] private int initialPoolSize = 30;

    private readonly Queue<GameObject> available =
        new Queue<GameObject>();

    private readonly List<GameObject> active =
        new List<GameObject>();

    private float nextSpawnX;
    private float spawnTimer = 0f;

    void Start()
    {
        if (player == null || obstaclePrefab == null)
        {
            Debug.LogError("ObstacleSpawner: Missing references!");
            enabled = false;
            return;
        }

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obstacle = Instantiate(
                obstaclePrefab, transform);

            obstacle.SetActive(false);
            available.Enqueue(obstacle);
        }

        nextSpawnX = player.position.x + 8f;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;

            // Spawn at a fixed position to the right
            nextSpawnX = player.position.x + spawnAhead;
            SpawnObstacle();
        }

        // Recycle obstacles that have moved past the player
        for (int i = active.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = active[i];

            if (obstacle.transform.position.x <
                player.position.x - despawnBehind)
            {
                obstacle.SetActive(false);
                active.RemoveAt(i);
                available.Enqueue(obstacle);
            }
        }
    }

    void SpawnObstacle()
    {
        GameObject obstacle;

        if (available.Count > 0)
        {
            obstacle = available.Dequeue();
        }
        else
        {
            obstacle = Instantiate(
                obstaclePrefab, transform);
        }

        bool onTop = Random.value > 0.5f;
        float y = onTop ? topY : bottomY;

        obstacle.transform.position =
            new Vector3(nextSpawnX, y, 0f);

        obstacle.SetActive(true);
        active.Add(obstacle);
    }
}

