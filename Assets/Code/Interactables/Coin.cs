using UnityEngine;
using System.Collections;

public class Coin : Interactables
{

    #region Public - interactions
    public override void PlayerCollided()
    {
        SceneEvents.CoinPickup.CallEvent();
    }
    #endregion

    void Update()
    {
        MoveUpdate();
    }
}