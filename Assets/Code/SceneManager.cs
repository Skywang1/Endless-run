using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;


    public delegate void GameStartIntro();
    public static event GameStartIntro OnGameStartIntro;

    public delegate void PlayerDead();
    public static event PlayerDead OnPlayerDead;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (OnPlayerDead != null)
            OnPlayerDead();
    }

    void Update()
    {

    }

    public void AnimEvent_CharacterEntered ()
    {

    }
}

/*
  public delegate void ClickAction();
    public static event ClickAction OnClicked;

    void Start()
    {
        if (OnClicked != null)
            OnClicked();
    }
 */