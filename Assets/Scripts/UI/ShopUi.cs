using UnityEngine;
using TMPro;

public class ShopUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _walletScoreText;

    private void Start()
    {
        RefreshWalletScore();
    }

    public void RefreshWalletScore()
    {
        _walletScoreText.text = RunSession.WalletScore.ToString("N0") + "P"; 
    }
}
