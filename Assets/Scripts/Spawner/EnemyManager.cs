using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    void Start()
    {
        SpawnNewEnemy();
    }

    void OnEnable()
    {
        EnemyAI.OnEnemyKilled += SpawnNewEnemy;
    }

    void SpawnNewEnemy()
    {
        int randomNumber = Random.Range(1, 11);
        Instantiate(enemyPrefab, spawnPoints[randomNumber].transform.position, Quaternion.identity);
    }
}
