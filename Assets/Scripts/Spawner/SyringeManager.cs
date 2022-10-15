using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject syringePrefab;

    void Start()
    {
        SpawnNewSyringe();
    }

    void OnEnable()
    {
        PlayerStats.onSyringeUsed += SpawnNewSyringe;
    }

    void SpawnNewSyringe()
    {
        int randomNumber = Random.Range(1, 10);
        Instantiate(syringePrefab, spawnPoints[randomNumber].transform.position, Quaternion.identity);
    }
}
