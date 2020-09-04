using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinScore : MonoBehaviour
{
    public Text coins;

    public void SetCoins(int amount)
    {
        coins.text = amount.ToString();
    }
}