using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour
{
    
    public Text distance;
    public Text coins;
    public Text timer;

    bool startedTimer = false;
    float timeElapsed;

    void Start()
    {
        
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

    public void SetDistance(int amount)
    {
        distance.text = amount.ToString();
    }
    #endregion

    #region Private


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
        distance.enabled = true;
        coins.enabled = true;
    }

    void CloseHUD()
    {
        distance.enabled = false;
        coins.enabled = false;
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

        timer.text = minutes + ":" + seconds;
    }
    #endregion
}