using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemyAlive;

    [Header("Wave settings")]
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    public float timeBetweenEnemiesSpawn = 0.4f;

    [Header("Unity stuff")]
    public Text waveCountdownText;

    [Header("Game manager")]
    public GameManager gameManager;

    private int waveNumber = 0;

    private float countDown = 3f;

    void Start()
    {
        EnemyAlive = 0;
    }

    void Update()
    {
        if (EnemyAlive > 0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            countDown = 0;
            waveCountdownText.text = string.Format("{0:00.00}", countDown);
            this.enabled = false;
        }

        if (!(waveNumber == waves.Length))
            if (countDown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countDown = timeBetweenWaves;
                return;
            }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveNumber];

        EnemyAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(timeBetweenEnemiesSpawn *
                    wave.rate);
        }

        waveNumber++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
