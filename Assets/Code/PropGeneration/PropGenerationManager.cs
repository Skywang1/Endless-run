using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlatformGenerator))]
public class PropGenerationManager : MonoBehaviour
{
    //Have the prop generation code in these seperate classes so that we don't 
    //clutter this class, and to allow them have their own unique generation logic.
    PropGeneratorBase platformGenerator;
    PropGeneratorBase boxGenerator;
    PropGeneratorBase coinGenerator;
    PropGeneratorBase enemyGenerator;

    void Start()
    {
        EventScribing();
        boxGenerator = GetComponent<BoxGenerator>();
        coinGenerator = GetComponent<CoinGenerator>();
        enemyGenerator = GetComponent<EnemyGenerator>();
        platformGenerator   = GetComponent<PlatformGenerator>();
    }


    #region Spawn start & stop
    void StartSpawn ()
    {
        boxGenerator.StartSpawn();
        coinGenerator.StartSpawn();
        
        enemyGenerator.StartSpawn();
        //platformGenerator.StartSpawn();
    }

    void StopSpawn ()
    {
        boxGenerator.StopSpawn();
        coinGenerator.StopSpawn();
        
        enemyGenerator.StopSpawn();
        //platformGenerator.StopSpawn();
    }
    #endregion

    #region Event subscribing
    void EventScribing()
    {
        //Subscribing to StopSpawn twice to allow us to halt spawning in both playerDead
        //event as well as when we quit game by pressing PauseMenu's Quit button
        SceneEvents.RunningStart.Event          += StartSpawn;
        SceneEvents.PlayerDead.Event            += StopSpawn;
        SceneEvents.GameOverBackToMain.Event    += StopSpawn; 
    }

    void OnDisable()
    {
        SceneEvents.RunningStart.Event          -= StartSpawn;
        SceneEvents.PlayerDead.Event            -= StopSpawn;
        SceneEvents.GameOverBackToMain.Event    -= StopSpawn;
    }
    #endregion

}