using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class WalletPersistence : MonoBehaviour
{
    private Wallet wallet;

    private void Awake()
    {
        wallet = GetComponent<Wallet>();

        WalletSave.Load(wallet);
        wallet.Changed += SaveWallet;
    }

    private void SaveWallet()
    {
        WalletSave.Save(wallet);
    }

    private void OnApplicationPause(bool paused)
    {
        if (paused)
            SaveWallet();
    }

    private void OnApplicationQuit()
    {
        SaveWallet();
    }

    private void OnDestroy()
    {
        if (wallet != null)
            wallet.Changed -= SaveWallet;
    }
}

