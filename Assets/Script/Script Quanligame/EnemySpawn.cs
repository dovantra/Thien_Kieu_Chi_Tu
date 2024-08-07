using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class EnemySpawn : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject[] prefabspawn;
    [Header("Atributes")]
    [SerializeField] private int baseEnemy = 8;
    [SerializeField] private float EnemyperSecond = 2f;
    [SerializeField] private float timeBetweenWaves = 5f;

    public static UnityEvent OnEnemyDestroy = new UnityEvent();



    private int currentwave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlives;
    private int enemisLefttoSpawn;// so quai con lai 

    private float difficutlySalingFactor = 0.75f;
    private bool isSpawning = false;

    public void Awake()
    {
        OnEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void Start()
    {
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        if (!isSpawning)
            return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= 1f / EnemyperSecond && enemisLefttoSpawn > 0)
        {
            SpawnEnemy();
            Debug.Log(" yes");

            enemisLefttoSpawn--;
            enemiesAlives++;
            timeSinceLastSpawn = 0f;

        }

        if (enemiesAlives == 0 && enemisLefttoSpawn == 0)
        {
            EndWave();
        }
    }
    private void SpawnEnemy()
    {
        int indexRadom = Random.Range(1, prefabspawn.Length);
        GameObject prefabtoSpawn = prefabspawn[indexRadom];
        Instantiate(prefabtoSpawn, LeverManager.main.StartPoint.position, Quaternion.identity);
    }


    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemisLefttoSpawn = EnemiesPerWave();

    }
    public void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentwave++;
        StartCoroutine(StartWave());

    }
    public void EnemyDestroyed()
    {

        enemiesAlives--;
    }


    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemy * Mathf.Pow(currentwave, difficutlySalingFactor));
    }
}
