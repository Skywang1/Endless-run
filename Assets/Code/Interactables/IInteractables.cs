using UnityEngine;

public abstract class Interactables: MonoBehaviour
{
    //CONST
    const float leftBound = -20f; //The point at which this object will be destroyed

    protected Vector3 moveDir = new Vector3(-5f, 0f, 0f);

    public virtual void PlayerCollided() { }

    protected void MoveUpdate ()
    {
        //Move
        transform.Translate(moveDir * Time.deltaTime);

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}