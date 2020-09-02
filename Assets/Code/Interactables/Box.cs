using UnityEngine;
using System.Collections;

public class Box : Interactables
{
    public float moveSpeed = 2f;
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