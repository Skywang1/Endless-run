using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //FIELDS
    public static SceneManager instance;    

    public MainMenuCanvasTransition mainMenuCanvasTransition; //Handles canvas transition

    //VARIABLES
    [SerializeField]
    float characterEnterDuration = 1f; //

    //References
    HUDManager HUD;

    //Const
    const int StartingHealth = 3; //Max health

    //Properties
    public static GameStates gameState { get; private set; }
    public int Health { get; private set; }
    public int Coins { get; private set; } 
    public int TimeElapsed { get; private set; } //In game timer

    #region MonoBehavior

    private void Awake()
    {
        instance = this;

        SceneEvents.Initialize();

        gameState = GameStates.MainMenu;
        Health = 3;
        Coins = 0;
    }

    void Start()
    {
        HUD = HUDManager.instance;
        EventScribing();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ReduceHealth();
        }
        if (Input.GetKeyDown(KeyCode.C))
            CoinPickup(100);
    }
    #endregion

    #region Public - stats changes
    public void CoinPickup(int value =  10)
    {
        Coins += value;
        HUD.SetCoins(Coins);
    }

    public void ResetStats()
    {
        Health = StartingHealth;
        TimeElapsed = 0;
        Coins = 0;

        HUD.SetCoins(Coins);
        HUD.SetHealth(Health);
    }

    public void ReduceHealth ()
    {
        if (gameState == GameStates.Running )
        {
            if (--Health <= 0)
            {
                SceneEvents.PlayerDead.CallEvent();
            }
            else
            {
                HUD.SetHealth(Health);
            }
        }
    }
    #endregion

    #region Scene state transitions
    //GAME START
    void GameStart ()
    {
        ResetStats();
        gameState = GameStates.MainMenu;
        StartCoroutine(DelayedStartRunning());
    }

    IEnumerator DelayedStartRunning()
    {
        yield return new WaitForSeconds(characterEnterDuration);
        SceneEvents.RunningStart.CallEvent();
    }

    //RUNNING START
    void RunningStart() => gameState = GameStates.Running;    

    //SCOREBOARD
    void PlayerDead()
    {
        gameState = GameStates.Scoreboard;
    }

    //BACK TO MAIN
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