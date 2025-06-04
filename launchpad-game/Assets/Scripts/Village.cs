using UnityEngine;

public class Village : MonoBehaviour
{
    public GameObject workerPrefab;
    public Transform spawnPoint;

    public float timeBetweenSpawns;
    public int numberOfWorkersToSpawn;
    float nextSpawnTime;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time > nextSpawnTime && numberOfWorkersToSpawn > 0)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;

            Instantiate(workerPrefab, spawnPoint.position, Quaternion.identity);

            numberOfWorkersToSpawn--;

            if (numberOfWorkersToSpawn <= 0) {
                Destroy(gameObject);
            }           
        }
    }
}
