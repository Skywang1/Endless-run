using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinGenerator : PropGeneratorBase
{

    //protected override IEnumerator DoSpawn ()
    //{
    //    while (spawning)
    //    {
    //        switch (Random.Range(0, 4))
    //        {
    //            case 0:
    //                yield return StartCoroutine(SpawnCoinLinearSequence());
    //                break;
    //            case 1:
    //                yield return StartCoroutine(SpawnTwoRowCoins());
    //                break;
    //            case 2:
    //                yield return StartCoroutine(SpawnZigZagCoins());
    //                break;
    //            default:
    //                //Empty
    //                break;
    //        }
    //        yield return new WaitForSeconds(Random.Range(2f, 3f));
    //    }
    //}

    //IEnumerator SpawnCoinLinearSequence()
    //{
    //    Vector3 pos = GetRandomSpawnPoint_Coins().position;
    //    for (int i = 0; i < Random.Range(1, 5); i++)
    //    {
    //        SpawnSingleCoin(pos);
    //        yield return new WaitForSeconds(coinSpawnDelay);
    //    }
    //}

    //IEnumerator SpawnTwoRowCoins()
    //{
    //    //Spawn 2 rows of 4~8 coins
    //    int index1 = Random.Range(1, spawnPoints_coins.Count - 1);
    //    int index2 = index1 - 1;
    //    Vector3 pos1 = spawnPoints_coins[index1].position;
    //    Vector3 pos2 = spawnPoints_coins[index2].position;

    //    for (int i = 0; i < Random.Range(4, 9); i++)
    //    {
    //        SpawnSingleCoin(pos1);
    //        SpawnSingleCoin(pos2);
    //        yield return new WaitForSeconds(coinSpawnDelay);
    //    }
    //}

    //IEnumerator SpawnZigZagCoins()
    //{
    //    int strokes = 0;

    //    int high = Random.Range(2, spawnPoints_coins.Count - 1);
    //    int low = high - 2;
    //    int index = high;

    //    bool rise = false;

    //    while (strokes < 6)
    //    {
    //        SpawnSingleCoin(spawnPoints_coins[index].position);

    //        //If the zig zag is moving up...
    //        if (rise)
    //        {
    //            //... and reaches the top index, then start moving down,
    //            if (index >= high)
    //            {
    //                rise = false;
    //                strokes++;
    //                index--;
    //            }
    //            //otherwise pick the next index above.
    //            else
    //            {
    //                index++;
    //            }
    //        }
    //        //If the zig zag is moving down...
    //        else
    //        {
    //            //... and reaches the bottom index, then start moving up,
    //            if (index <= low)
    //            {
    //                rise = true;
    //                strokes++;
    //                index++;
    //            }
    //            //otherwise pick the next index below.
    //            else
    //            {
    //                index--;
    //            }
    //        }
    //        yield return new WaitForSeconds(coinSpawnDelay);
    //    }
    //}

}