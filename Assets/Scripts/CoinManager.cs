using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;

    public int CoinsCollected { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void CollectCoin()
    {
        CoinsCollected++;

        if (Wallet.Instance != null)
        {
            Wallet.Instance.Earn(5);
        }
        else
        {
            Debug.LogError("Wallet not found!");
        }

        if (audioSource != null && pickupSound != null)
            audioSource.PlayOneShot(pickupSound);

        Debug.Log("Coins collected: " + CoinsCollected);
    }
}