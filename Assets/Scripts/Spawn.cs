using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPosition;
    [SerializeField] GameObject[] gameObjects;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 0.5f);
    }

    private void SpawnEnemy()
    {
        Vector3 spawn = spawnPosition[Random.Range(0, spawnPosition.Length)].position;
        Instantiate(gameObjects[Random.Range(0, gameObjects.Length)], new(spawn.x, spawn.y), Quaternion.identity);
    }
}
