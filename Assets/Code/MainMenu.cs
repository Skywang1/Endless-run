using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Dropdown Dropdown_Qualities;
    public Dropdown Dropdown_Resolutions;
    public Toggle Toggle_Fullscreen;


    const int SceneIndex_Running = 1;
    const string Key_Fullscreen = "Fullscreen";
    const string Key_Width = "Width";
    const string Key_Height = "Height";


    Resolution[] allResolutions;
    bool isFullscreen;

    #region MonoBehavior
    void Start()
    {
        Load();

        //Populate quality
        Dropdown_Resolutions.ClearOptions();
        allResolutions = Screen.resolutions;
        List<string> options = new List<string>();
        int resolutionIndex = 0;

        // Print the resolutions
        for (int i = 0; i < allResolutions.Length; i++)
        {
            options.Add(allResolutions[i].width + "x" + allResolutions[i].height);

            if (Screen.width == allResolutions[i].width && Screen.height == allResolutions[i].height)
            {
                resolutionIndex = i;
            }
        }

        Dropdown_Resolutions.AddOptions(options);
        Dropdown_Resolutions.value = resolutionIndex;
        Dropdown_Resolutions.RefreshShownValue();
    }

    void Update()
    {

    }
    #endregion

    #region Public
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneIndex_Running);
    }

    public void SetResolution (int index)
    {

    }

    public void SetQuality (int index)
    {


    }

    public void SaveSettings ()
    {
        Save();
    }
    #endregion

    #region Load/Save
    void Load()
    {
        isFullscreen = PlayerPrefs.GetInt(Key_Fullscreen, Screen.fullScreen ? 1 : 0)  == 1 ? true : false;
        Toggle_Fullscreen.isOn = isFullscreen;
    }

    void Save()
    {

    }
    #endregion
}
