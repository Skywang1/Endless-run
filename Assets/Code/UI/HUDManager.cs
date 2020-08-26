using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour
{
    public GameObject HUD_Group;
    public Text coins;
    public Text timer;

    bool startedTimer = false;
    float timeElapsed;

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
        coins.text = amount.ToString();
    }
    #endregion

    #region Event subscribing
    void SubscribeEvents ()
    {
        SceneManager.OnCharacterEnter += HUDInitialization;
        SceneManager.OnCharacterDead += CloseHUD;
    }

    void OnDisable()
    {
        SceneManager.OnCharacterEnter -= HUDInitialization;
        SceneManager.OnCharacterDead -= CloseHUD;
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
}

/*
 void UpdateTimer()
    {
        timeElapsed += Time.deltaTime;
        string minutes = Mathf.Floor(timeElapsed / 60f).ToString("00");
        string seconds = Mathf.Floor(timeElapsed % 60).ToString("00");

        timer.text = minutes + ":" + seconds;
    }
 */