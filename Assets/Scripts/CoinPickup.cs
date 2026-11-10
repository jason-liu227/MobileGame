using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private CoinPool pool;

    public void SetPool(CoinPool coinPool)
    {
        pool = coinPool;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        CoinManager.Instance.CollectCoin();

        if (pool != null)
            pool.Release(this);
        else
            gameObject.SetActive(false);
    }

    public void ReturnToPool()
    {
        if (pool != null)
            pool.Release(this);
        else
            gameObject.SetActive(false);
    }
}


