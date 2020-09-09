using UnityEngine;
using System.Collections;

public class CoinCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D + " + collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("coin hits player");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D + " + collision.gameObject.name);
        if (collision.tag == "Player")
        {
            Debug.Log("coin hits player");
        }
    }
}