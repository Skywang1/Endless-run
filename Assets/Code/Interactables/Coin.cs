using UnityEngine;
using System.Collections;

public class Coin : Interactables
{
    //EVENT
    public delegate void CoinPickupEvent();
    public static event CoinPickupEvent OnCoinPickup;

    #region Public - interactions
    public override void PlayerCollided()
    {
        if (OnCoinPickup != null)
        {
            OnCoinPickup();
        }
    }
    #endregion

    void Update()
    {
        MoveUpdate();
    }
}