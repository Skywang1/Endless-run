using UnityEngine;

public abstract class Interactables: MonoBehaviour
{
    public float baseMoveSpeed = -5f;

    protected SceneManager sceneManager;
    protected Vector3 moveDir;

    //CONST
    const float leftBound = -20f; //The point at which this object will be destroyed

    public virtual void PlayerCollided() { }

    #region MonoBehaviour
    protected void Start()
    {
        Subscribe();

        sceneManager = SceneManager.instance;

        moveDir = new Vector3(baseMoveSpeed * GlobalSpeedModifier.Speed, 0f, 0f);
    }
    #endregion

    #region Subscription
    void Subscribe()
    {
        SceneEvents.SpeedIncrease.Event += SpeedUp;
        SceneEvents.PlayerDead.Event += Destroy;
    }

    protected void OnDisable()
    {
        SceneEvents.SpeedIncrease.Event -= SpeedUp;
        SceneEvents.PlayerDead.Event -= Destroy;
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

    protected virtual void MoveUpdate ()
    {
        //Move
        transform.Translate(moveDir * Time.deltaTime, Space.World);

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    protected void Destroy ()
    {
        Destroy(gameObject);
    }
}