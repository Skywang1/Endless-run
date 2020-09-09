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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.instance.ReduceHealth();
            Destroy(gameObject);
        }
    }
}