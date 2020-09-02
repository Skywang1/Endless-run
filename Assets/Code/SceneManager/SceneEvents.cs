using UnityEngine;
using System.Collections;

//This class if for calling major game events
//Game Start >>> Running Start >>> Player Dead >>> Back to main
public static class SceneEvents
{
    //Game start: player clicks Start, camera begins to zoom out
    public delegate void Event_GameStart();
    public static event Event_GameStart OnGameStart;

    //Running start: camera fully zoomed out, character entered scene and running
    public delegate void Event_RunningStart();
    public static event Event_RunningStart OnRunningStart;

    //On speed increase
    public delegate void Event_PassiveSpeedIncrease(float newGlobalSpeed);
    public static event Event_PassiveSpeedIncrease OnSpeedIncrease;

    //Player dead
    public delegate void Event_PlayerDead();
    public static event Event_PlayerDead OnPlayerDead;

    public delegate void Event_GameOverBackToMain();
    public static event Event_GameOverBackToMain OnGameOverBackToMain;

    public static void Call_GameStarts ()
    {
        OnGameStart?.Invoke();
    }

    public static void Call_RunningStarts()
    {
        OnRunningStart?.Invoke();
    }

    public static void Call_SpeedIncrease(float newGlobalSpeed)
    {
        OnSpeedIncrease?.Invoke(newGlobalSpeed);
    }

    public static void Call_PlayerDead()
    {
        OnPlayerDead?.Invoke();
    }

    public static void Call_GameOverBackToMain()
    {
        OnGameOverBackToMain?.Invoke();
    }
}