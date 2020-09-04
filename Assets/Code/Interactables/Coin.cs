using UnityEngine;
using System.Collections;

public class Coin : Interactables
{

    #region Public - interactions
    public override void PlayerCollided()
    {
        SceneManager.instance.CoinPickup();
        Destroy(gameObject);
    }
    #endregion

    void Update()
    {
        MoveUpdate();
    }
}