using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //FIELDS
    public static SceneManager instance;    

    public MainMenuCanvasTransition mainMenuCanvasTransition;

    //VARIABLES
    [SerializeField]
    float characterEnterDuration = 1f;

    HUDManager HUD;

    //Properties
    public static GameStates gameState { get; private set; }
    public int Health { get; private set; }
    public int Coins { get; private set; }
    public int TimeElapsed { get; private set; }

    #region MonoBehavior

    private void Awake()
    {
        instance = this;
        
        gameState = GameStates.MainMenu;
        Health = 3;
        Coins = 0;
    }

    void Start()
    {
        HUD = HUDManager.instance;
        EventScribing();
    }
    #endregion

    #region Public - stats changes
    public void CoinPickup()
    {
        HUD.SetCoins(++Coins);
    }

    public void ResetStats()
    {
        TimeElapsed = 0;
        Coins = 0;
        HUD.SetCoins(Coins);
    }
    #endregion

    #region public - Game Phases
    public void Clicked_GameStart()
    {
        ResetStats();
        SceneEvents.GameStart.CallEvent();        
        StartCoroutine(DelayedStartRunning());
    }

    IEnumerator DelayedStartRunning()
    {
        yield return new WaitForSeconds(characterEnterDuration);
        SceneEvents.RunningStart.CallEvent();
    }

    public void CharacterDead()
    {
        SceneEvents.PlayerDead.CallEvent();
        SceneEvents.GameOverBackToMain.CallEvent();
        //Play scoreboard animation
    }
    #endregion

    #region Set scene state
    void GameStart () => gameState = GameStates.MainMenu;
    void RunningStart() => gameState = GameStates.Running;    
    void PlayerDead() => gameState = GameStates.Scoreboard;
    void GameOverBackToMain() => gameState = GameStates.MainMenu;
    #endregion

    #region Event subscribing
    void EventScribing()
    {
        SceneEvents.RunningStart.Event          += RunningStart;
        SceneEvents.GameStart.Event             += GameStart;
        SceneEvents.PlayerDead.Event            += PlayerDead;
        SceneEvents.GameOverBackToMain.Event    += GameOverBackToMain;
    }

    void OnDisable()
    {
        SceneEvents.RunningStart.Event          -= RunningStart;
        SceneEvents.GameStart.Event             -= GameStart;
        SceneEvents.PlayerDead.Event            -= PlayerDead;
        SceneEvents.GameOverBackToMain.Event    -= GameOverBackToMain;
    }
    #endregion
}