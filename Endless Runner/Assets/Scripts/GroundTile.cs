using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] GameObject ObstaclePrefab;
    [SerializeField] GameObject TallObstaclePrefab;
    [SerializeField] GameObject PoisonPrefab;


    [SerializeField] float tallObstacleChance = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update() { }

    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = ObstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = TallObstaclePrefab;
        }

        //Choose a random point to spawn the obstacle
        int ObstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(ObstacleSpawnIndex).transform;

        //Spawn the obstacle at that position
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(CoinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    public void SpawnPoison()
    {
        int coinsToSpawn = 2;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(PoisonPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            1,
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        return point;
    }
}
