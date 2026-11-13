using UnityEngine;

public static class WalletSave
{
    private const string CoinsKey = "wallet.coins";
    private const string LevelKey = "wallet.level";

    public static void Save(Wallet wallet)
    {
        PlayerPrefs.SetInt(CoinsKey, wallet.Coins);
        PlayerPrefs.SetInt(LevelKey, wallet.Level);
        PlayerPrefs.Save();
    }

    public static void Load(Wallet wallet)
    {
        int coins = PlayerPrefs.GetInt(CoinsKey, 0);
        int level = PlayerPrefs.GetInt(LevelKey, 0);

        wallet.Restore(coins, level);
    }
}

