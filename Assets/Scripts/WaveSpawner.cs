using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    private bool finishedSpawning;
    [SerializeField] private Timer testTimer;
    [SerializeField] GameObject endGameMenu;

    private void Start()
    {
        waves[0].timeBetweenSpawns = GameManager.instance.spawnGame;
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];
        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];

            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            if (i == currentWave.count - 1)
            {
                if (!testTimer.GetTime())
                {
                    i = 0;
                }
                else
                {
                    finishedSpawning = true;
                }
            }
            else
            {
                finishedSpawning = false;
            }

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }

    private void Update()
    {
        if (player == null)
        {
            StartCoroutine(EndGame());
        }
        else
        {
            if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                finishedSpawning = false;
                if (currentWaveIndex + 1 < waves.Length)
                {
                    currentWaveIndex++;
                    StartCoroutine(StartNextWave(currentWaveIndex));
                }
                else
                {
                    StartCoroutine(EndGame());
                }
            }
        }

    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        endGameMenu.SetActive(true);
    }
}
