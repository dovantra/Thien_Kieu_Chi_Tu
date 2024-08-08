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
    [SerializeField] private int baseEnemy = 8;   // số kẻ địch trong 1 map
    [SerializeField] private float EnemyperSecond = 2f;
    [SerializeField] private float timeBetweenWaves = 5f;  
    [SerializeField] private int sodiemquaibatdau;   

    public static UnityEvent OnEnemyDestroy = new UnityEvent(); // cập nhật sự kiện mượt mà hơn



    private int currentwave = 1;           // wave hiện tại
    private float timeSinceLastSpawn;     // thời gian từ lượt cuối đẻ ra
    private int enemiesAlives;                  // số kẻ địch đang sống
    private int enemisLefttoSpawn;// so quai con lai để ra

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

        if (enemiesAlives == 0 && enemisLefttoSpawn == 0)   // điều kiện kết thúc wave
        {
            EndWave();
        }
    }
    private void SpawnEnemy()
    {
        int i = Random.RandomRange(0, sodiemquaibatdau-1);  // quai ra radom ở các điểm khác nhau

        int indexRadom = Random.Range(0, prefabspawn.Length-1);
        GameObject prefabtoSpawn = prefabspawn[indexRadom];
        Instantiate(prefabtoSpawn, LeverManager.main.StartPoint[i].position, Quaternion.identity);
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
