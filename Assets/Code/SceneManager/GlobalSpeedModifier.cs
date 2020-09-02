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
    float accelerationAmount = 0.01f;
    bool gameStarted = false;
    float currentSpeed = STARTING_SPEED;
    
    #region MonoBehaviour
    private void Update()
    {
        //Let the game gradually slowdown after game is over
        if (!gameStarted)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, STARTING_SPEED, Time.deltaTime);
        }
    }
    #endregion

    #region Speed change
    void StartGame()
    {
        gameStarted = true;
        StartCoroutine(SpeedUp());
    }

    IEnumerator SpeedUp ()
    {
        while (gameStarted)
        {
            currentSpeed += accelerationAmount;
            SceneEvents.Call_SpeedIncrease(currentSpeed);
            yield return new WaitForSeconds(accelerationInterval);
        }
    }

    void EndRunning()
    {
        gameStarted = false;
    }
    #endregion

    #region Event subscribing
    void EventSubscribing()
    {
        SceneEvents.OnGameStart += StartGame;
        SceneEvents.OnPlayerDead += EndRunning;
    }

    void OnDisable()
    {
        SceneEvents.OnGameStart -= StartGame;
        SceneEvents.OnPlayerDead -= EndRunning;
    }
    #endregion
}