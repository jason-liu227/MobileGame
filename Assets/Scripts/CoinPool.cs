
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private CoinPickup coinPrefab;
    [SerializeField] private int poolSize = 12;

    private readonly Queue<CoinPickup> available =
        new Queue<CoinPickup>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CoinPickup coin = Instantiate(coinPrefab, transform);
            coin.SetPool(this);
            coin.gameObject.SetActive(false);
            available.Enqueue(coin);
        }
    }

    public void Spawn(Vector3 position, float speed)
    {
        if (available.Count == 0)
            return;

        CoinPickup coin = available.Dequeue();
        coin.transform.position = position;
        coin.gameObject.SetActive(true);

        CoinMovement movement =
            coin.GetComponent<CoinMovement>();

        movement.SetSpeed(speed);
    }

    public void Release(CoinPickup coin)
    {
        coin.gameObject.SetActive(false);
        available.Enqueue(coin);
    }
}

