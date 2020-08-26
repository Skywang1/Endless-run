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

        SceneManager.OnCharacterEnter += ZoomIn;
        SceneManager.OnCharacterDead += ZoomOut;

        animator = GetComponent<Animator>();

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

    void OnDisable()
    {
        SceneManager.OnCharacterEnter -= ZoomIn;
        SceneManager.OnCharacterDead -= ZoomOut;
    }
}
