using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle1; // Префаб для первого препятствия (слева)
    public GameObject obstacle2; // Префаб для второго препятствия (справа)
    public GameObject obstacle3; // Префаб для третьего препятствия (случайное положение)
    public GameObject obstacle4; // Префаб для четвертого препятствия (случайное положение)
    public float checkRadius = 1.0f; // Радиус проверки наличия других объектов

    private float spawnInterval = 2.0f;

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnRandomObstacle();
        }
    }

    private void SpawnRandomObstacle()
    {
        int obstacleIndex = Random.Range(0, 4);
        GameObject obstacleToSpawn = null;
        Vector3 spawnPosition = Vector3.zero;

        switch (obstacleIndex)
        {
            case 0:
                obstacleToSpawn = obstacle1;
                spawnPosition = new Vector3(-2.0f, 7.0f, 0.0f);
                break;
            case 1:
                obstacleToSpawn = obstacle2;
                spawnPosition = new Vector3(2.0f, 7.0f, 0.0f);
                break;
            case 2:
                obstacleToSpawn = obstacle3;
                spawnPosition = new Vector3(Random.Range(-2.0f, 2.0f), 7.0f, 0.0f);
                break;
            case 3:
                obstacleToSpawn = obstacle4;
                spawnPosition = new Vector3(Random.Range(-2.0f, 2.0f), 7.0f, 0.0f);
                break;
        }

        if (IsPositionFree(spawnPosition))
        {
            Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private bool IsPositionFree(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, checkRadius);
        return colliders.Length == 1;
    }
}
