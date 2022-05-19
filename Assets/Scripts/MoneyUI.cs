using TMPro;
using UnityEngine;
public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinTextValue;
    [SerializeField]private Player play;
    public void CoinPlus()
    {
        play._moneyPlayer += 10;
        MoneyPlayer();
    }
    public void MoneyPlayer()
    {
        string moneyCoin = "Money: " + play._moneyPlayer;
        _coinTextValue.SetText(moneyCoin);
    }
}
