using UnityEngine;
using System.Collections;

namespace MainMenu
{
    public class MainMenu_PanelTransition : MonoBehaviour
    {
        public CanvasGroup MainMenu;
        public CanvasGroup OptionsMenu;

        [Range(0, 5f)]
        public float TransitionDuration = 1f;

        bool inTransition = false;

        #region Initialization
        void Awake()
        {
            InstantHide(OptionsMenu);
            InstantHide(OptionsMenu);
            StartCoroutine(DelayedInitialFade());
        }

        private void Update()
        {
            
        }

        IEnumerator DelayedInitialFade()
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(CanvasFadeIn(MainMenu));
        }
        #endregion

        #region Public - transition call
        public void MainToOptions()
        {
            if (!inTransition)
            {
                StartCoroutine(CanvasTransition(MainMenu, OptionsMenu));
            }
        }

        public void OptionsToMain()
        {
            if (!inTransition)
            {
                StartCoroutine(CanvasTransition(OptionsMenu, MainMenu));
            }
        }
        #endregion


        #region Transition logics
        IEnumerator CanvasTransition(CanvasGroup canvasToHide, CanvasGroup canvaToReveal)
        {
            inTransition = true;

            //Disale 
            canvasToHide.interactable = false;
            canvasToHide.blocksRaycasts = false;

            float t = 0;
            while (t < TransitionDuration)
            {
                t += Time.deltaTime;
                canvaToReveal.alpha = t / TransitionDuration;
                canvasToHide.alpha = 1 - (t / TransitionDuration);

                yield return null;
            }

            canvaToReveal.interactable = true;
            canvaToReveal.blocksRaycasts = true;

            inTransition = false;
        }

        IEnumerator CanvasFadeIn(CanvasGroup canvas)
        {
            inTransition = true;

            float t = 0;
            while (t < TransitionDuration)
            {
                t += Time.deltaTime;
                canvas.alpha = t / TransitionDuration;

                yield return null;
            }

            canvas.interactable = true;
            canvas.blocksRaycasts = true;

            inTransition = false;
        }

        void InstantHide(CanvasGroup canvasToHide)
        {
            canvasToHide.interactable = false;
            canvasToHide.blocksRaycasts = false;
            canvasToHide.alpha = 0f;
        }
        #endregion
    }
}