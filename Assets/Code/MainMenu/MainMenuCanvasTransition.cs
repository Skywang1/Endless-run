using UnityEngine;
using System.Collections;

public class MainMenuCanvasTransition : MonoBehaviour
{
    public CanvasGroup MainMenu;
    public CanvasGroup OptionsMenu;

    [Range(0, 5f)]
    float TransitionDuration = 0.1f;

    bool inTransition = false;

    #region Initialization
    void Start()
    {
        EventSubscription();

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
            StartCoroutine(CanvasGroupHelper.CrossfadeCoroutine(MainMenu, OptionsMenu, TransitionDuration));
        }
    }

    public void OptionsToMain()
    {
        if (!inTransition)
        {
            StartCoroutine(CanvasGroupHelper.CrossfadeCoroutine(OptionsMenu, MainMenu, TransitionDuration));
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

    #region Singular fade
    void FadeOutMainMenu ()
    {
        Debug.Log("fade out");
        StartCoroutine(CanvasGroupHelper.FadeOutCoroutine(MainMenu, TransitionDuration));
    }

    void FadeInMainMenu ()
    {
        StartCoroutine(DelayedFadeIn_MainMenu());
    }

    IEnumerator DelayedFadeIn_MainMenu()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CanvasGroupHelper.FadeInCoroutine(MainMenu, TransitionDuration));
    }
    #endregion


    #region Scene events subscription
    void EventSubscription()
    {
        SceneEvents.GameStart.Event             += FadeOutMainMenu;
        SceneEvents.GameOverBackToMain.Event    += FadeInMainMenu;
    }

    void OnDisable()
    {
        SceneEvents.GameStart.Event             -= FadeOutMainMenu;
        SceneEvents.GameOverBackToMain.Event    -= FadeInMainMenu;
    }
    #endregion
}