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
        SceneEvents.GameStart.CallEvent();

        StartCoroutine(DelayedStartRunning());
    }

    IEnumerator DelayedStartRunning()
    {
        yield return new WaitForSeconds(characterEnterDuration);
        SceneEvents.RunningStart.CallEvent();

        ResetStats();
    }

    public void CharacterDead()
    {
        SceneEvents.PlayerDead.CallEvent();
        //Play scoreboard animation
    }
    #endregion

    #region Event subscribing
    void EventScribing()
    {
        SceneEvents.CoinPickup.Event += CoinPickup;
    }

    void OnDisable()
    {
        SceneEvents.CoinPickup.Event -= CoinPickup;
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