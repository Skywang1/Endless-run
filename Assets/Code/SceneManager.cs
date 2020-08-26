using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    //EVENTS
    public delegate void CharacterEnterEvent();
    public static event CharacterEnterEvent OnCharacterEnter;

    public delegate void StartRunningEvent();
    public static event StartRunningEvent OnStartRunning;

    public delegate void PlayerDeadEvent();
    public static event PlayerDeadEvent OnCharacterDead;

    //VARIABLES
    [SerializeField]
    float characterEnterDuration = 1f;


    void Start()
    {
        if (OnCharacterDead != null)
            OnCharacterDead();
    }

    void Update()
    {

    }

    #region Events

    #endregion
    public void CharacterEnter ()
    {
        if (OnCharacterEnter != null)
        {
            OnCharacterEnter();
        }
        StartCoroutine(DelayToStartRunning());
    }

    IEnumerator DelayToStartRunning ()
    {
        yield return new WaitForSeconds(characterEnterDuration);
        if (OnStartRunning != null)
        {
            OnStartRunning();
        }
    }

    public void CharacterDead ()
    {
        if (OnCharacterDead != null)
        {
            OnCharacterDead();
        }
    }

    public void AnimEvent_CharacterEntered ()
    {

    }
}
