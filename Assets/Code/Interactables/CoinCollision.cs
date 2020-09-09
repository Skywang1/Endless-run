using UnityEngine;
using System.Collections;

public class CoinCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("coin hits player");
        }
    }
}