using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject enemy;

    private float spawnTimer = 2f;
    private float spawnRateIncrease = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNextEnemy());
        StartCoroutine(SpawnRateIncrease());
    }

    private IEnumerator SpawnNextEnemy()
    {
        int nextSpawnLocation = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[nextSpawnLocation].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnTimer);

        if (!GameManager.instance.gameOver)
        {
            StartCoroutine(SpawnNextEnemy());
        }
    }

    private IEnumerator SpawnRateIncrease()
    {
        yield return new WaitForSeconds(spawnRateIncrease);

        if (spawnTimer >= 0.5f)
        {
            spawnTimer -= 0.2f;
        }

        StartCoroutine(SpawnRateIncrease());
    }
}
