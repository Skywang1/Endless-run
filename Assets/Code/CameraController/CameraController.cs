using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Animator animator;
    int anim_zoomIn;
    int anim_zoomOut;

    void Start()
    {
        anim_zoomIn = Animator.StringToHash("ZoomIn");
        anim_zoomOut = Animator.StringToHash("ZoomOut");

        animator = GetComponent<Animator>();
        EventSubscription();
    }

    void Update()
    {
        
    }

    void ZoomOut()
    {
        animator.Play(anim_zoomOut);
    }

    void ZoomIn ()
    {
        animator.Play(anim_zoomIn);
    }

    #region Scene events subscription
    void EventSubscription ()
    {
        SceneEvents.GameStart.Event += ZoomOut;
        SceneEvents.PlayerDead.Event += ZoomIn;
    }

    void OnDisable()
    {
        SceneEvents.PlayerDead.Event -= ZoomIn;
        SceneEvents.GameStart.Event -= ZoomOut;
    }
    #endregion
}