
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public Dropdown Dropdown_Qualities;
    public Dropdown Dropdown_Resolutions;
    public Toggle Toggle_Fullscreen;

    //Use stored consts to call scene transition and save playerprefs, to avoid
    //making a typo.
    const int SceneIndex_Running = 1;
    const string Key_Fullscreen = "Fullscreen";
    const string Key_Quality = "Quality";
    const string Key_Width = "Width";
    const string Key_Height = "Height";

    //Cache Options menu values as fields so we can save them in player prefs later.
    //Resolution[] allResolutions;
    List<Resolution> resolutions;
    bool isFullscreen;
    int resolutionIndex = -1;
    int qualityIndex;

    void Start()
    {
        Load_OptionsSettings();
    }

    #region Public - Options Menu UI Interactions
    public void SetResolution(int index)
    {
        //Note: we cannot put Dropdown_Resolutions.value in here, as when the dropdown (ui element)'s value is changed, it
        //will trigger it's onValueChange event, thus creating a circular loop. Therefore we can only directly set the
        //dropdown values outside.
        resolutionIndex = index;

        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);
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

    #region public Load/Save - for when you enter and exit the options menu
    public void Load_OptionsSettings()
    {
        //Load isFullscreen & set value in UI
        isFullscreen = PlayerPrefs.GetInt(Key_Fullscreen, Screen.fullScreen ? 1 : 0) == 1 ? true : false;
        //Debug.Log("isFullscreen " + isFullscreen);
        Toggle_Fullscreen.isOn = isFullscreen;
        SetFullScreen(isFullscreen);

        //Load quality & set value in UI
        qualityIndex = PlayerPrefs.GetInt(Key_Quality, 0);
        Dropdown_Qualities.value = qualityIndex;
        SetQuality(qualityIndex);

        //Load resolution & set value in UI (Do not set resolution)
        PopulateResolutionDropdownBox();
        LoadResolution();
    }

    public void Save_OptionsSettings()
    {
        //Save isFullscreen
        PlayerPrefs.SetInt(Key_Fullscreen, isFullscreen == true ? 1 : 0);
        //Debug.Log("Save isFullscreen " + isFullscreen);
        //Debug.Log("PlayerPrefs.GetInt(Key_Fullscreen, Screen.fullScreen " + PlayerPrefs.GetInt(Key_Fullscreen, -1));

        //Save quality
        PlayerPrefs.SetInt(Key_Quality, qualityIndex);

        //Save resolution
        PlayerPrefs.SetInt(Key_Width, resolutions[resolutionIndex].width);
        PlayerPrefs.SetInt(Key_Height, resolutions[resolutionIndex].height);
    }
    #endregion

    #region Private - Loading resolution
    void PopulateResolutionDropdownBox()
    {
        Dropdown_Resolutions.ClearOptions();

        //Goal: Go through all resolutions, save them as strings, then populate the dropdown box's options with it.
        //Note: We use the following line instead of "allResolutions = Screen.resolutions;" to prevent returning duplicates 
        //of the same resolution in the build version.
        resolutions = Screen.resolutions.ToList();
        
        //supportedResolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToList();
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Count; i++)
        {
            string s = resolutions[i].width + "x" + resolutions[i].height + "@" + resolutions[i].refreshRate;
            if (!options.Contains(s))
            {
                options.Add(s);
            }
        }
        //if (options.Contains(option));
        Dropdown_Resolutions.AddOptions(options);
        Dropdown_Resolutions.RefreshShownValue();
    }

    //This method will try to load screen resolution by 
    //1. Load from player prefs
    //2. If player prefs doesn't contain a saved resolution data..
    //... then pick a supportedResolution that matches the screen.
    //3. If no supportedResolution matches the screen...
    //... then pick the largest supportedResolution (i.e. the last index).
    void LoadResolution()
    {
        if (resolutions == null || resolutions.Count == 0)
        {
            PopulateResolutionDropdownBox();
        }

        //1. Try load screen resolution from PlayerPrefs 
        int saved_w = PlayerPrefs.GetInt(Key_Width, 0);
        int saved_h = PlayerPrefs.GetInt(Key_Height, 0);

        if (saved_w != 0 && saved_h != 0)
        {
            Debug.Log("Has saved resolution data in PlayerPrefs.");
            for (int i = 0; i < resolutions.Count; i++)
            {
                if (saved_w == resolutions[i].width &&
                    saved_h == resolutions[i].height)
                {
                    Dropdown_Resolutions.value = i;
                    SetResolution(i);

                    Debug.Log("Matching resolution data found in playerPrefs. Exiting LoadResolution().");
                    return;
                }
            }
            Debug.Log("Saved resolution data was found but is not in the list of supportedResolutions.");
        }
        else
        {
            Debug.Log("No saved resolution setting.");
        }

        //2. See if there is a supported resolution that matches the screen.
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.currentResolution.width == resolutions[i].width &&
                Screen.currentResolution.height == resolutions[i].height)
            {
                Dropdown_Resolutions.value = i;
                SetResolution(i);

                Debug.Log("SupportedResolutions contains an option that matches the Screen.width and Screen.height. Exiting LoadResolution().");
                return;
            }
        }
        Debug.Log("SupportedResolutions DOES NOT contain an option that matches the screen.");

        //3. Pick the largest supportedResolution
        Debug.Log("Picking the last option in supportedResolutions.");

        Dropdown_Resolutions.value = resolutions.Count - 1;
        SetResolution(resolutions.Count - 1);
    }
    #endregion
}