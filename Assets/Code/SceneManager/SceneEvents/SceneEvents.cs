using UnityEngine;
using System.Collections;

//This class if for calling major game events
//Game Start >>> Running Start >>> Player Dead >>> Back to main
public static class SceneEvents 
{
    //Game start: player clicks Start, camera begins to zoom out
    public static SceneEvent GameStart { get; private set; }

    //Running start: camera fully zoomed out, character entered scene and running
    public static SceneEvent RunningStart { get; private set; }

    public static SceneEvent SpeedIncrease { get; private set; }
    public static SceneEvent PlayerDead { get; private set; }
    public static SceneEvent GameOverBackToMain { get; private set; }

    public static void Initialize()
    {
        GameStart   = new SceneEvent("Game start");
        RunningStart = new SceneEvent("Running start");
        SpeedIncrease = new SceneEvent("+");
        PlayerDead = new SceneEvent("Player dead");
        GameOverBackToMain = new SceneEvent("Back to main");
    }

    public static void UnSubscribeAll()
    {
        GameStart.Unsubscribe();
        RunningStart.Unsubscribe();
        SpeedIncrease.Unsubscribe();
        PlayerDead.Unsubscribe();
        GameOverBackToMain.Unsubscribe();
    }
}