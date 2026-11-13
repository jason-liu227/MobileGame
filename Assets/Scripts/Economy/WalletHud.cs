using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WalletHud : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsLabel;
    [SerializeField] private TMP_Text upgradeLabel;
    [SerializeField] private Button upgradeButton;

    private Wallet wallet;

    private void OnEnable()
    {
        wallet = Wallet.Instance;

        if (wallet == null)
        {
            Debug.LogError("Wallet not found!");
            return;
        }

        wallet.Changed += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        if (wallet != null)
            wallet.Changed -= Refresh;
    }

    private void Refresh()
    {
        coinsLabel.SetText("{0}", wallet.Coins);
        upgradeLabel.SetText("Upgrade ({0})", wallet.NextCost);
        upgradeButton.interactable = wallet.Coins >= wallet.NextCost;
    }

    public void OnUpgrade()
    {
        wallet.TryUpgrade();
    }
}
