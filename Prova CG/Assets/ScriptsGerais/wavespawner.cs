using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavespawner : MonoBehaviour
{
    [SerializeField] private float contagem;

    [SerializeField] private GameObject spawnPoint;

    public Wave[] waves;

    private int currentWaveIndex = 0;

    private void Update()
    {
        contagem -= Time.deltaTime;

        if (contagem <= 0)
        {
            contagem = waves[currentWaveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);

            yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
        }

    }
}

[System.Serializable]
 public class Wave
{
    public Fallen_bot[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;
}
