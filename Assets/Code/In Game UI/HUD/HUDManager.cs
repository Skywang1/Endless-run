using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    public GameObject HUD_Group;
    public HealthBar healthBar;
    public CoinScore coinScore;
    
    public Text timer;

    bool startedTimer = false;
    float timeElapsed;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SubscribeEvents();
    }

    void Update()
    {
        if (startedTimer)
        {
            UpdateTimer();
        }
    }

    #region Public - Setting values
    public void SetCoins (int amount)
    {
        coinScore.SetCoins(amount);
    }

    public void SetHealth(int amount)
    {
        healthBar.SetHealth(amount);
    }
    #endregion

    #region HUD visibility
    void HUDInitialization()
    {
        //Reset HUD
        ResetTimer();
        startedTimer = true;

        //Reveal HUD
        HUD_Group.SetActive(true);
    }

    void CloseHUD()
    {
        HUD_Group.SetActive(false);
    }
    #endregion

    #region HUD Timer
    void ResetTimer ()
    {
        timeElapsed = 0f;
    }

    void UpdateTimer()
    {
        timeElapsed += Time.deltaTime;
        string minutes = Mathf.Floor(timeElapsed / 60f).ToString("00");
        string seconds = Mathf.Floor(timeElapsed % 60).ToString("00");
        string miliseconds = Mathf.Floor((timeElapsed * 100) % 100).ToString("00");

        timer.text = minutes + ":" + seconds + ":" + miliseconds;
    }
    #endregion

    #region Event subscribing
    void SubscribeEvents()
    {
        SceneEvents.GameStart.Event += HUDInitialization;
        SceneEvents.PlayerDead.Event += CloseHUD;
    }

    void OnDisable()
    {
        SceneEvents.GameStart.Event -= HUDInitialization;
        SceneEvents.PlayerDead.Event -= CloseHUD;
    }
    #endregion
}
