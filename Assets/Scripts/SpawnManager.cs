using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spongebobPrefab;
    public int spongebobCount;
    public int waveNumber = 1;

    private float spawnRange = 45;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        spongebobCount = FindObjectsOfType<SpongebobControls>().Length;
        if(spongebobCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i=0; i<enemiesToSpawn; i++)
        {
            Instantiate(spongebobPrefab, GenerateSpawnPosition(), spongebobPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 2, spawnPosZ);
        return randomPos;
    }
}
