using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Dropdown Qualities;
    public Dropdown Resolutions;
    public Toggle FullScreen;


    const int SceneIndex_Running = 1;


    #region MonoBehavior
    void Start()
    {

    }

    void Update()
    {

    }
    #endregion

    #region Public
    public void PlayGame ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneIndex_Running);
    }
    #endregion

    #region Load/Save
    void Load ()
    { 

    }

    void Save ()
    {

    }
    #endregion
}
