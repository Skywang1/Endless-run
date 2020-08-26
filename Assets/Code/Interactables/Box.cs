using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour, IInteractables
{
    [SerializeField]
    float moveSpeed = 5f;
    Vector3 moveDir;

    //public void Spawn (Vector3 p)
    //{
    //    transform.position = p;
    //}

    #region Public - interactions
    public void PlayerCollided()
    {

    }
    #endregion

    void Start()
    {
        moveDir = new Vector3(-moveSpeed, 0f, 0f);
    }

    void Update()
    {
        //Move
        transform.Translate(moveDir * Time.deltaTime);

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}