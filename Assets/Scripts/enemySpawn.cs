using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawn : MonoBehaviour
{
    [Header("playerSpawn")]
    [SerializeField] private GameObject playerToSpawn;
    [SerializeField] private GameObject[] normalEnemyToSpawn;
    [SerializeField] private GameObject specialEnemyToSpawn;
    [SerializeField] private GameObject bossEnemyToSpawn;

    [Header("Location Spawn")]
    [SerializeField] private Transform playerLocationSpawn;
    [SerializeField] private Transform[] nsEnemyLocationSpawn;
    [SerializeField] private Transform bossEnemyLocationSpawn;

    [Header("Tools")]
    [SerializeField] private int enemyCount;
    [SerializeField] private float spawnRate=1.0f;
    [SerializeField] private float timeBetweenWaves=3f;

    bool waveIsDone = true;
    public int waveCount;
    [SerializeField] private Text waveCountText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (enemyCount <=10)
        {
            InvokeRepeating("Spawn", 5, 3);
        }else if (enemyCount > 10)
        {
            waveIsDone = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Spawn()
    {
        if (waveIsDone)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;
        GameObject enemy = Instantiate(normalEnemyToSpawn[Random.Range(0, normalEnemyToSpawn.Length - 1)], nsEnemyLocationSpawn[Random.Range(0, nsEnemyLocationSpawn.Length - 1)]);
        yield return new WaitForSeconds(spawnRate);
        enemyCount++;
        spawnRate -= 0.1f;
        yield return new WaitForSeconds(timeBetweenWaves);
        waveIsDone = true;
    }

    public void playerSpawn()
    {
        GameObject player = Instantiate(playerToSpawn, playerLocationSpawn);
    }
}
