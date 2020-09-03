using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlatformGenerator))]
public class PropGenerationManager : MonoBehaviour
{
    bool spawning = false;

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
        spawning = true;
        boxGenerator.StartSpawn();
        coinGenerator.StartSpawn();
        
        enemyGenerator.StartSpawn();
        platformGenerator.StartSpawn();
    }

    void StopSpawn ()
    {
        spawning = false;
        boxGenerator.StopSpawn();
        coinGenerator.StopSpawn();
        
        enemyGenerator.StopSpawn();
        platformGenerator.StopSpawn();
    }
    #endregion

    #region Event subscribing
    void EventScribing()
    {
        SceneEvents.RunningStart.Event += StartSpawn;
        SceneEvents.PlayerDead.Event += StopSpawn;
    }

    void OnDisable()
    {
        SceneEvents.RunningStart.Event -= StartSpawn;
        SceneEvents.PlayerDead.Event -= StopSpawn;
    }
    #endregion

}