
using UnityEngine;

public class CoinShop : MonoBehaviour
{
    private IPurchaseProvider purchaseProvider;
    private bool purchasing;

    private void Awake()
    {
        purchaseProvider = new FakePurchaseProvider();
    }

    public async void OnBuyPack()
    {
        if (purchasing)
            return;

        purchasing = true;

        try
        {
            bool success =
                await purchaseProvider.PurchaseAsync("coins_500");

            if (success && Wallet.Instance != null)
            {
                Wallet.Instance.Earn(500);
                Debug.Log("[iap-stub] awarded 500 coins");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
        finally
        {
            purchasing = false;
        }
    }
}
