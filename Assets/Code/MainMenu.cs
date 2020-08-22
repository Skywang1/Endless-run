using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

//Make sure the game's quality settings only have 3 options, as we won't be changing them here.
public class MainMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public Dropdown Dropdown_Qualities;
    public Dropdown Dropdown_Resolutions;
    public Toggle Toggle_Fullscreen;

    const int SceneIndex_Running = 1;
    const string Key_Fullscreen = "Fullscreen";
    const string Key_Quality = "Quality";
    const string Key_Resolution = "Resolution";

    //Cache Options menu values as fields so we can save them in player prefs later.
    Resolution[] allResolutions;
    bool isFullscreen;
    int resolutionIndex;
    int qualityIndex;

    #region MonoBehavior
    void Start()
    {
        Load_OptionsSettings();
    }

    void OnGUI ()
    {
        GUI.Label(new Rect(20, 20, 2000, 20), "Quality: " + QualitySettings.GetQualityLevel());
        GUI.Label(new Rect(20, 40, 2000, 20), "isFullscreen: " + isFullscreen);
    }
    #endregion

    #region Public - Main menu
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneIndex_Running);
    }

    public void Quit ()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
    #endregion

    #region Public - Options Menu

    public void SetResolution(int index)
    {
        resolutionIndex = index;
        if (allResolutions.Length == 0)
        {
            PopulateResolutionDropdownBox();
        }

        Screen.SetResolution(allResolutions[index].width, allResolutions[index].height, Screen.fullScreen);
    }

    public void SetQuality(int index)
    {
        qualityIndex = index;
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullScreen(bool b)
    {
        isFullscreen = b;
        Screen.fullScreen = b;
    }
    #endregion

    #region Load/Save
    public void Load_OptionsSettings()
    {
        //Load isFullscreen & set value in UI
        isFullscreen = PlayerPrefs.GetInt(Key_Fullscreen, Screen.fullScreen ? 1 : 0) == 1 ? true : false;
        Debug.Log("isFullscreen " + isFullscreen);
        Toggle_Fullscreen.isOn = isFullscreen;
        SetFullScreen(isFullscreen);

        //Load quality & set value in UI
        qualityIndex = PlayerPrefs.GetInt(Key_Quality, 0);
        Dropdown_Qualities.value = qualityIndex;
        SetQuality(qualityIndex);

        //Load resolution & set value in UI (Do not set resolution)
        resolutionIndex = PlayerPrefs.GetInt(Key_Resolution, 0);
        PopulateResolutionDropdownBox();
    }

    public void Save_OptionsSettings()
    {
        //Save isFullscreen
        PlayerPrefs.SetInt(Key_Fullscreen, isFullscreen == true ? 1 : 0);
        Debug.Log("isFullscreen " + isFullscreen);
        Debug.Log("PlayerPrefs.GetInt(Key_Fullscreen, Screen.fullScreen " + PlayerPrefs.GetInt(Key_Fullscreen, -1));

        //Save quality
        PlayerPrefs.SetInt(Key_Quality, qualityIndex);

        //Save resolution
        PlayerPrefs.SetInt(Key_Resolution, resolutionIndex);
    }
    #endregion

    #region Private
    void PopulateResolutionDropdownBox()
    {
        Dropdown_Resolutions.ClearOptions();

        //Go through all resolutions, save them as strings, then populate the dropdown box's options with it.
        allResolutions = Screen.resolutions;
        List<string> options = new List<string>();

        for (int i = 0; i < allResolutions.Length; i++)
        {
            options.Add(allResolutions[i].width + "x" + allResolutions[i].height);

            //Cache the correct dropbox option index
            if (Screen.currentResolution.width == allResolutions[i].width &&
                Screen.currentResolution.height == allResolutions[i].height)
            {
                resolutionIndex = i;
            }
        }

        Dropdown_Resolutions.AddOptions(options);
        Dropdown_Resolutions.value = resolutionIndex;
        Dropdown_Resolutions.RefreshShownValue();
    }
    #endregion
}

/*
 * We won't be using this, as we want the resolutions to be 16:9, and not the resolutions 
 * that the player's monitor supports.
 * 
     void PopulateResolutionDropdownBox()
    {
        Dropdown_Resolutions.ClearOptions();

        //Go through all resolutions, save them as strings, then populate the dropdown box's options with it.
        allResolutions = Screen.resolutions;
        List<string> options = new List<string>();

        for (int i = 0; i < allResolutions.Length; i++)
        {
            options.Add(allResolutions[i].width + "x" + allResolutions[i].height);

            //Cache the correct dropbox option index
            if (Screen.currentResolution.width == allResolutions[i].width &&
                Screen.currentResolution.height == allResolutions[i].height)
            {
                resolutionIndex = i;
            }
        }

        Dropdown_Resolutions.AddOptions(options);
        Dropdown_Resolutions.value = resolutionIndex;
        Dropdown_Resolutions.RefreshShownValue();
    }
 
 */