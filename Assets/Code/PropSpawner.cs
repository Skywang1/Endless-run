using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    public GameObject[] Pf_Boxes;
    public GameObject Pf_Coin;

    public List<Transform> spawnPoints_coins;
    public List<Transform> spawnPoints_boxes;

    const float coinSpawnDelay = 0.29f;

    bool spawning = false;
        
    void Start()
    {
        EventScribing();
    }

    void Update()
    {
        
    }


    #region Event subscribing
    void EventScribing()
    {
        SceneManager.OnStartRunning += StartSpawn;
        SceneManager.OnCharacterDead += StopSpawn;
    }

    void OnDisable()
    {
        SceneManager.OnStartRunning -= StartSpawn;
        SceneManager.OnCharacterDead -= StopSpawn;
    }
    #endregion

    #region Spawn setup
    void StartSpawn ()
    {
        spawning = true;
        StartCoroutine(DoCoinSpawns());
        StartCoroutine(DoBoxSpawns());
    }

    void StopSpawn ()
    {
        spawning = false;
    }
    #endregion

    #region Coin spawning sequences
    IEnumerator DoCoinSpawns ()
    {
        while(spawning)
        {
            switch (Random.Range(0, 4))
            {
                case 0: //Spawn random coin
                    SpawnSingleCoin(GetRandomSpawnPoint_Coins().position);
                    yield return new WaitForSeconds(Random.Range(0.5f, 1f));
                    break;
                case 1:
                    StartCoroutine(SpawnTripleCoins());
                    yield return new WaitForSeconds(Random.Range(3f, 4f));
                    break;
                case 2:
                    StartCoroutine(SpawnTwoRowCoins());
                    yield return new WaitForSeconds(Random.Range(3f, 4f));
                    break;
                case 3:
                    StartCoroutine(SpawnZigZagCoins());
                    yield return new WaitForSeconds(Random.Range(4f, 6f));
                    break;
            }
        }
    }

    IEnumerator SpawnTripleCoins ()
    {
        Vector3 pos = GetRandomSpawnPoint_Coins().position;
        for (int i = 0; i < 3; i++)
        {
            SpawnSingleCoin(pos);
            yield return new WaitForSeconds(coinSpawnDelay);
        }
    }

    IEnumerator SpawnTwoRowCoins ()
    {
        //Spawn 2 rows of 4~8 coins
        int index1 = Random.Range(1, spawnPoints_coins.Count - 1);
        int index2 = index1 - 1;
        Vector3 pos1 = spawnPoints_coins[index1].position;
        Vector3 pos2 = spawnPoints_coins[index2].position;

        for (int i = 0; i < Random.Range(4, 9); i++)
        {
            SpawnSingleCoin(pos1);
            SpawnSingleCoin(pos2);
            yield return new WaitForSeconds(coinSpawnDelay);
        }
    }

    IEnumerator SpawnZigZagCoins ()
    {
        int strokes = 0;

        int high = Random.Range(2, spawnPoints_coins.Count - 1);
        int low = high - 2;
        int index = high;

        bool rise = false;

        while (strokes < 5)
        {
            SpawnSingleCoin(spawnPoints_coins[index].position);

            //If the zig zag is moving up...
            if (rise)
            {
                //... and reaches the top index, then start moving down,
                if (index >= high)
                {
                    rise = false;
                    strokes++;
                    index--;
                }
                //otherwise pick the next index above.
                else
                {
                    index++;
                }
            }
            //If the zig zag is moving down...
            else
            {
                //... and reaches the bottom index, then start moving up,
                if (index <= low)
                {
                    rise = true;
                    strokes++;
                    index++;
                }
                //otherwise pick the next index below.
                else
                {
                    index--;
                }
            }

            yield return new WaitForSeconds(coinSpawnDelay);
        }
    }
    #endregion

    #region Box spawning sequences
    IEnumerator DoBoxSpawns ()
    {
        while (spawning)
        {
            SpawnBoxSmall(GetRandomSpawnPoint_Boxes().position);
            yield return new WaitForSeconds(Random.Range(1f, 5f));

            //switch (Random.Range(0, 2))
            //{
            //    case 0:
            //        SpawnBoxSmall(GetRandomSpawnPoint_Boxes().position);
            //        yield return new WaitForSeconds(Random.Range(2f, 5f));
            //        break;

            //    case 1:
            //        SpawnBoxBig(GetRandomSpawnPoint_Boxes().position);
            //        yield return new WaitForSeconds(Random.Range(3f, 6f));
            //        break;
            //}            
        }
    }
    #endregion

    #region Instantiation
    void SpawnSingleCoin(Vector3 pos)
    {
        Instantiate(Pf_Coin, pos, Quaternion.identity);
    }

    void SpawnCoin (int index)
    {
        Instantiate(Pf_Coin, spawnPoints_coins[index].position, Quaternion.identity);
    }

    void SpawnBoxSmall(Vector3 pos)
    {
        Instantiate(Pf_Boxes[0], pos, Quaternion.identity);
    }

    //void SpawnBoxBig(Vector3 pos)
    //{
    //    Instantiate(Pf_Boxes[1], pos, Quaternion.identity);
    //}
    #endregion

    #region Get spawn point
    Transform GetRandomSpawnPoint_Coins ()
    {
        return spawnPoints_coins[Random.Range(0, spawnPoints_coins.Count)];
    }

    Transform GetRandomSpawnPoint_Boxes()
    {
        return spawnPoints_boxes[Random.Range(0, spawnPoints_boxes.Count)];
    }
    #endregion
}