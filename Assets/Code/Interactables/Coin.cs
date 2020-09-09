using UnityEngine;
using System.Collections;

public class Coin : Interactables
{
    [SerializeField] float rotation = 10f;

    #region Public - interactions
    public override void PlayerCollided()
    {
        SceneManager.instance.CoinPickup();
        Destroy(gameObject);
    }
    #endregion

    void Update()
    {
        transform.rotation = GlobalRotation.CoinRotation;
        //transform.Rotate(new Vector3(0f, 0f, rotation * Time.deltaTime));
        MoveUpdate();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.instance.CoinPickup();
            Destroy(gameObject);
        }
    }
}