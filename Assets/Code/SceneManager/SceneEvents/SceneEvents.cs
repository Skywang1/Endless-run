using UnityEngine;
using System.Collections;

//This class if for calling major game events
//Game Start >>> Running Start >>> Player Dead >>> Back to main
public class SceneEvents : MonoBehaviour
{
    //Game start: player clicks Start, camera begins to zoom out
    public static SceneEvent GameStart { get; private set; }

    //Running start: camera fully zoomed out, character entered scene and running
    public static SceneEvent RunningStart { get; private set; }

    public static SceneEvent SpeedIncrease { get; private set; }
    public static SceneEvent PlayerDead { get; private set; }
    public static SceneEvent GameOverBackToMain { get; private set; }

    void Awake()
    {
        GameStart   = new SceneEvent();
        RunningStart = new SceneEvent();
        SpeedIncrease = new SceneEvent();
        PlayerDead = new SceneEvent();
        GameOverBackToMain = new SceneEvent();
    }
}


