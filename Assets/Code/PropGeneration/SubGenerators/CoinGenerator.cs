using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

public class CoinGenerator : PropGeneratorBase
{
    int previousPattern = -1;



protected override IEnumerator DoSpawn ()
    {
        while (spawning)
        {
            switch (GetRandomPatternIndex(0, 4))
            {
                case 0:
                    yield return StartCoroutine(SpawnCoinLinearSequence());
                    break;
                case 1:
                    yield return StartCoroutine(SpawnTwoRowCoins());
                    break;
                case 2:
                    yield return StartCoroutine(SpawnZigZagCoins());
                    break;
                default:
                    //Empty
                    break;
            }
            yield return new WaitForSeconds(spawnIntervalMax);
        }
    }

    IEnumerator SpawnCoinLinearSequence()
    {
        Vector3 pos = GetRandomSpawnPoint.position;

        int i = 0;
        int end = Random.Range(1, 5);
        while (spawning & i < end)
        {
            i++;
            SpawnAtPosition(pos);
            yield return new WaitForSeconds(spawnIntervalMin);
        }
    }

    IEnumerator SpawnTwoRowCoins()
    {
        //Spawn 2 rows of 4~8 coins
        int index1 = Random.Range(1, spawnPoints.Count - 1);
        int index2 = index1 - 1;
        Vector3 pos1 = spawnPoints[index1].position;
        Vector3 pos2 = spawnPoints[index2].position;

        int i = 0;
        int end = Random.Range(4, 9);
        {
            i++;
            SpawnAtPosition(pos1);
            SpawnAtPosition(pos2);
            yield return new WaitForSeconds(spawnIntervalMin);
        }
    }

    IEnumerator SpawnZigZagCoins()
    {
        int strokes = 0;

        int high = Random.Range(2, spawnPoints.Count - 1);
        int low = high - 2;
        int index = high;

        bool rise = false;

        while (spawning && strokes < 4)
        {
            SpawnAtPosition(spawnPoints[index].position);

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
            yield return new WaitForSeconds(spawnIntervalMin);
        }
    }


    int GetRandomPatternIndex(int min, int max)
    {
        int _new;
        do
        {
            _new = Random.Range(min, max);
        }
        while (_new == Random.Range(min, max));
        previousPattern = _new;
        return _new;
    }
}