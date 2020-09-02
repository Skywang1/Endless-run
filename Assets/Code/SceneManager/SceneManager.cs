using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //FIELDS
    public static int phase = 0;

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
        SceneEvents.Call_GameStarts();

        StartCoroutine(DelayedStartRunning());
    }

    IEnumerator DelayedStartRunning()
    {
        yield return new WaitForSeconds(characterEnterDuration);
        SceneEvents.Call_RunningStarts();

        ResetStats();
    }

    public void CharacterDead()
    {
        SceneEvents.Call_PlayerDead();
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