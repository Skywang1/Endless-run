using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    [SerializeField] GameObject HUD_Group;
    [SerializeField] HealthBar healthBar;
    [SerializeField] CoinScore coinScore;

    [SerializeField] Text timer;

    bool startedTimer = false;
    float timeElapsed;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CloseHUD();
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

    public void ResetTimer()
    {
        timeElapsed = 0f;
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
