using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Linq;

//Make sure the game's quality settings only have 3 options, as we won't be changing them here.
//Note 1: This code does not save the resolution set by the player because every time the game opens, it saves the 

public class MainMenuManager : MonoBehaviour
{
    #region Public - Main menu
    public void PlayGame()
    {
        SceneEvents.GameStart.CallEvent();
    }

    public void Quit ()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
    #endregion

}
