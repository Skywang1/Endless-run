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

    void ZoomIn ()
    {
        animator.Play(anim_zoomIn);
    }

    void ZoomOut()
    {
        animator.Play(anim_zoomOut);
    }

    #region Scene events subscription
    void EventSubscription ()
    {
        SceneEvents.PlayerDead.Event += ZoomIn;
        SceneEvents.GameStart.Event += ZoomOut;
    }

    void OnDisable()
    {
        SceneEvents.PlayerDead.Event -= ZoomIn;
        SceneEvents.GameStart.Event -= ZoomOut;
    }
    #endregion
}