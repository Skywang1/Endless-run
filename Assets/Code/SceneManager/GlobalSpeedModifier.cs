using UnityEngine;
using System.Collections;

public class GlobalSpeedModifier : MonoBehaviour
{
    //This class manages a global speed-modifier that increases overtime. 
    //This variable will be referenced by sprites to determine how fast they 
    //need to go.
    public static float Speed { get; private set; }

    //Const
    const float STARTING_SPEED = 1f;
    const float STARTING_MAXSPEED = 1f;

    //Variables
    float accelerationInterval = 1f;
    float accelerationAmount = 0.05f;
    bool SpeedIncreasing = false;

    #region MonoBehaviour
    private void Start()
    {
        Speed = STARTING_SPEED;
        EventSubscribing();
    }
    private void Update()
    {
        //Let the game gradually slowdown after game is over
        if (!SpeedIncreasing)
        {
            Speed = Mathf.Lerp(Speed, STARTING_SPEED, Time.deltaTime * 2f);
        }
    }
    #endregion

    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(20, 20, 200, 20), "Global Speed: " + Speed);
    //}

    #region Speed change
    void StartIncrease()
    {
        SpeedIncreasing = true;
        StartCoroutine(DoIncrease());
    }

    IEnumerator DoIncrease ()
    {
        while (SpeedIncreasing)
        {
            Speed += accelerationAmount;
            SceneEvents.SpeedIncrease.CallEvent();
            yield return new WaitForSeconds(accelerationInterval);
        }
    }

    void EndIncrease()
    {
        SpeedIncreasing = false;
    }
    #endregion

    #region Event subscribing
    void EventSubscribing()
    {
        SceneEvents.GameStart.Event += StartIncrease;
        SceneEvents.GameOverBackToMain.Event += EndIncrease;
    }

    void OnDisable()
    {
        SceneEvents.GameStart.Event += StartIncrease;
        SceneEvents.GameOverBackToMain.Event -= EndIncrease;
    }
    #endregion
}