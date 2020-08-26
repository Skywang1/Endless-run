using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup canvas_Pause;

    bool isPaused = false;

    void Start()
    {
        SetPause(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        SetPause(isPaused);
    }

    void SetPause(bool pause)
    {
        isPaused = pause;
        if (isPaused)
        {
            Time.timeScale = 0f;
            canvas_Pause.alpha = 1f;
            canvas_Pause.interactable = true;
            canvas_Pause.blocksRaycasts = true;
        }
        else
        {
            Time.timeScale = 1f;
            canvas_Pause.alpha = 0f;
            canvas_Pause.interactable = false;
            canvas_Pause.blocksRaycasts = false;
        }
    }
}
