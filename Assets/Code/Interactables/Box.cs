using UnityEngine;
using System.Collections;

public class Box : Interactables
{
    #region Public - interactions
    public override void PlayerCollided()
    {

    }
    #endregion


    void Update()
    {
        MoveUpdate();
    }
}