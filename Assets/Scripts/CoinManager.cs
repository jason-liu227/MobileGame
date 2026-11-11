using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private ScoreManager scoreManager;

    public int CoinsCollected { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void CollectCoin()
    {
        CoinsCollected++;

        if (scoreManager != null)
        {
            scoreManager.AddCoin();
        }

        if (audioSource != null && pickupSound != null)
            audioSource.PlayOneShot(pickupSound);

        Debug.Log("Coins: " + CoinsCollected);
    }
}

