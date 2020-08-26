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

    //FIELDS
    public HUDManager HUD;

    //VARIABLES
    [SerializeField]
    float characterEnterDuration = 1f;

    int coins;
    int score;
    int timeElapsed;

    #region MonoBehavior

    void Start()
    {
        EventScribing();
    }

    void Update()
    {

    }
    #endregion
    

    #region public - Game Phases
    public void Clicked_GameStart()
    {
        if (OnCharacterEnter != null)
        {
            OnCharacterEnter();
        }

        StartCoroutine(DelayedStartRunning());
    }

    IEnumerator DelayedStartRunning()
    {
        yield return new WaitForSeconds(characterEnterDuration);
        if (OnStartRunning != null)
        {
            OnStartRunning();
        }

        ResetStats();
    }

    public void CharacterDead()
    {
        if (OnCharacterDead != null)
        {
            OnCharacterDead();
        }

        //Play scoreboard animation
    }
    #endregion


    #region Event subscribing
    void EventScribing()
    {
        Coin.OnCoinPickup += CoinPickup;
    }

    void OnDisable()
    {
        Coin.OnCoinPickup -= CoinPickup;
    }
    #endregion


    #region Stats change
    void CoinPickup()
    {
        HUD.SetCoins(++coins);
    }

    void ResetStats()
    {
        timeElapsed = 0;
        score = 0;
    }
    #endregion
}
