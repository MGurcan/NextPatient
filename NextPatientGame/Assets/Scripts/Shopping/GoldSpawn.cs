using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawn : MonoBehaviour
{
    public GameObject gold;
    public Transform goldSpawnPoint;

    public void CreateGold()
    {
        Instantiate(gold, goldSpawnPoint.position, goldSpawnPoint.rotation);
    }
}
