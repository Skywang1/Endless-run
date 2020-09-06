using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup canvas_Pause;
    public GameObject PauseButton;

    bool isPaused = false;

    void Start()
    {        
        SubscribeEvents();
        
        HideAllPauseMenuElements();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)  && SceneManager.gameState == GameStates.Running)
        {
            TogglePause();
        }
    }

    #region Public - buttons
    public void TogglePause()
    {
        if (SceneManager.gameState == GameStates.Running)
        {
            isPaused = !isPaused;

            SetPause(isPaused);
        }        
    }

    public void PauseMenu_QuitGame()
    {
        SceneEvents.PlayerDead.CallEvent();
        isPaused = false;
        SetPause(isPaused);
    }
    #endregion

    #region Pause logic
    void SetPause(bool pause)
    {
        //Debug.Log("Set pause " + isPaused);
        isPaused = pause;
        if (isPaused)
        {
            Time.timeScale = 0f;
            CanvasGroupHelper.InstantReveal(canvas_Pause);
        }
        else
        {
            Time.timeScale = 1f;
            CanvasGroupHelper.InstantHide(canvas_Pause);
        }
    }

    void RevealPauseButton ()
    {
        PauseButton.SetActive(true);
    }

    void HideAllPauseMenuElements ()
    {
        SetPause(false);
        PauseButton.SetActive(false);
    }
    #endregion

    #region Event subscribing
    void SubscribeEvents()
    {
        SceneEvents.GameStart.Event += RevealPauseButton;
        SceneEvents.PlayerDead.Event += HideAllPauseMenuElements;
    }

    void OnDisable()
    {
        SceneEvents.GameStart.Event -= RevealPauseButton;
        SceneEvents.PlayerDead.Event -= HideAllPauseMenuElements;
    }
    #endregion
}
