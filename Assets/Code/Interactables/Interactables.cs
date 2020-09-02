using UnityEngine;

public abstract class Interactables: MonoBehaviour
{
    public float baseMoveSpeed = -5f;

    protected Vector3 moveDir;

    //CONST
    const float leftBound = -20f; //The point at which this object will be destroyed


    public virtual void PlayerCollided() { }

    #region MonoBehaviour
    protected void Start()
    {
        Subscribe();
        moveDir = new Vector3(baseMoveSpeed * GlobalSpeedModifier.Speed, 0f, 0f);
    }
    #endregion

    #region Subscription
    void Subscribe()
    {
        SceneEvents.SpeedIncrease.Event += SpeedUp;
    }

    protected void OnDisable()
    {
        SceneEvents.SpeedIncrease.Event -= SpeedUp;
    }
    #endregion

    #region Speed change
    protected void SpeedUp()
    {
        moveDir = new Vector3(baseMoveSpeed * GlobalSpeedModifier.Speed, 0f, 0f);
    }

    protected void SpeedReset()
    {
        moveDir = new Vector3(baseMoveSpeed, 0f, 0f);
    }
    #endregion

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