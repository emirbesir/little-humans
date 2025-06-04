using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyAmount;
    int maxEnemyAmount;

    public float timeBetweenSpawns;
    float nextSpawnTime;

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefab;

    public static EnemyManager instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        maxEnemyAmount = LevelManager.enemyCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime && enemyAmount < maxEnemyAmount)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;

            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomEnemy = enemyPrefab[Random.Range(0, enemyPrefab.Length)];

            Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);
            enemyAmount++;
        }

    }
}
