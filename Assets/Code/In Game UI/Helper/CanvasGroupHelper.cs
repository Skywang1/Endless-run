using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class CanvasGroupHelper
{
    public static IEnumerator CanvasCrossfade(CanvasGroup canvasToHide, CanvasGroup canvaToReveal, float transitionTime)
    {
        //Disale 
        canvasToHide.interactable = false;
        canvasToHide.blocksRaycasts = false;

        float t = 0;
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            canvaToReveal.alpha = t / transitionTime;
            canvasToHide.alpha = 1 - (t / transitionTime);

            yield return null;
        }

        canvaToReveal.interactable = true;
        canvaToReveal.blocksRaycasts = true;
    }

    public static IEnumerator CanvasFadeIn(CanvasGroup canvas, float transitionTime)
    {
        float t = 0;
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            canvas.alpha = t / transitionTime;

            yield return null;
        }

        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }

    public static IEnumerator CanvasFadeOut(CanvasGroup canvas, float transitionTime)
    {
        float t = transitionTime;
        while (t > 0)
        {
            t -= Time.deltaTime;
            canvas.alpha = t / transitionTime;

            yield return null;
        }

        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }

    public static void InstantHide(CanvasGroup canvasToHide)
    {
        canvasToHide.interactable = false;
        canvasToHide.blocksRaycasts = false;
        canvasToHide.alpha = 0f;
    }

    public static void InstantReveal(CanvasGroup canvasToHide)
    {
        canvasToHide.interactable = true;
        canvasToHide.blocksRaycasts = true;
        canvasToHide.alpha = 1f;
    }
}