using UnityEngine;
using System.Collections;

public class MainMenuCanvasTransition : MonoBehaviour
{
    public CanvasGroup MainMenu;
    public CanvasGroup OptionsMenu;

    [Range(0, 5f)]
    public float TransitionDuration = 1f;

    bool inTransition = false;

    #region Initialization
    void Start()
    {
        CanvasGroupHelper.InstantHide(MainMenu);
        CanvasGroupHelper.InstantHide(OptionsMenu);
        FadeInMainMenu();
    }    
    #endregion

    #region Public - crossfade
    public void MainToOptions()
    {
        if (!inTransition)
        {
            StartCoroutine(CanvasGroupHelper.CanvasCrossfade(MainMenu, OptionsMenu, TransitionDuration));
        }
    }

    public void OptionsToMain()
    {
        if (!inTransition)
        {
            StartCoroutine(CanvasGroupHelper.CanvasCrossfade(OptionsMenu, MainMenu, TransitionDuration));
        }
    }

    public void GameOverToMain ()
    {
        if (!inTransition)
        {
            CanvasGroupHelper.InstantReveal(MainMenu);
        }
    }
    #endregion

    #region Fade in mainmenu
    void FadeInMainMenu ()
    {
        StartCoroutine(CanvasGroupHelper.CanvasFadeIn(MainMenu, TransitionDuration));
    }

    IEnumerator DelayedFadeIn_MainMenu()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CanvasGroupHelper.CanvasFadeIn(MainMenu, TransitionDuration));
    }
    #endregion


    #region Scene events subscription
    void EventSubscription()
    {
        SceneEvents.GameOverBackToMain.Event += FadeInMainMenu;
    }

    void OnDisable()
    {
        SceneEvents.GameOverBackToMain.Event -= FadeInMainMenu;
    }
    #endregion
}