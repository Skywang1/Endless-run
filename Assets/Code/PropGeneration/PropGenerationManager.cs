using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlatformGenerator))]
public class PropGenerationManager : MonoBehaviour
{
    PropGeneratorBase platformGenerator;
    PropGeneratorBase boxGenerator;
    PropGeneratorBase coinGenerator;
    PropGeneratorBase enemyGenerator;

    void Start()
    {
        Debug.Log("start");
        EventScribing();
        boxGenerator = GetComponent<BoxGenerator>();
        coinGenerator = GetComponent<CoinGenerator>();
        enemyGenerator = GetComponent<EnemyGenerator>();
        platformGenerator   = GetComponent<PlatformGenerator>();
    }


    #region Spawn start & stop
    void StartSpawn ()
    {
        Debug.Log("Start spawn");
        boxGenerator.StartSpawn();
        coinGenerator.StartSpawn();
        
        enemyGenerator.StartSpawn();
        //platformGenerator.StartSpawn();
    }

    void StopSpawn ()
    {
        //boxGenerator.StopSpawn();
        coinGenerator.StopSpawn();
        
        enemyGenerator.StopSpawn();
        //platformGenerator.StopSpawn();
    }
    #endregion

    #region Event subscribing
    void EventScribing()
    {
        //Subbing twice to StopSpawn in case we quit game by pressing PauseMenu's Quit button
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