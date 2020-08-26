using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    public GameObject Pf_Box;
    public GameObject Pf_Coin;

    public List<Transform> spawnPoints_coins;
    public List<Transform> spawnPoints_boxes;
        
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    #region Instantiation
    void SpawnCoin(Vector3 pos)
    {
        Instantiate(Pf_Coin, pos, Quaternion.identity);
    }

    void SpawnBox(Vector3 pos)
    {
        Instantiate(Pf_Coin, pos, Quaternion.identity);
    }
    #endregion

}
