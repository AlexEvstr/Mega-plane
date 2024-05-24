using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Префаб монеты
    private float minSpawnInterval = 3.0f;
    private float maxSpawnInterval = 7.0f;
    private float spawnY = 7.0f;
    private float minX = -2.0f;
    private float maxX = 2.0f;
    private float minSpacing = 0.7f;
    private int maxCoinsPerRow = 3;
    public float checkRadius = 1.0f; // Радиус проверки наличия других объектов

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            int numberOfCoins = Random.Range(1, 9);
            Vector2[] positions = GeneratePositions(numberOfCoins);

            foreach (Vector2 position in positions)
            {
                if (IsPositionFree(position))
                {
                    Instantiate(coinPrefab, new Vector3(position.x, position.y, 0.0f), Quaternion.identity);
                }
            }
        }
    }

    private Vector2[] GeneratePositions(int numberOfCoins)
    {
        Vector2[] positions = new Vector2[numberOfCoins];
        bool[,] grid = new bool[10, 10]; // 10x10 сетка для проверки пересечений
        float currentY = spawnY;
        int coinsInRow = 0;

        for (int i = 0; i < numberOfCoins; i++)
        {
            Vector2 position;
            bool positionFound = false;
            int attempts = 0;

            do
            {
                float xPos = Mathf.Round(Random.Range(minX, maxX) / minSpacing) * minSpacing;

                position = new Vector2(
                    xPos,
                    currentY
                );

                int gridX = Mathf.RoundToInt((position.x - minX) / minSpacing);
                int gridY = Mathf.RoundToInt((position.y - spawnY) / minSpacing);

                if (gridX >= 0 && gridX < 10 && gridY >= 0 && gridY < 10 && !grid[gridX, gridY])
                {
                    grid[gridX, gridY] = true;
                    positionFound = true;
                }
                attempts++;
            } while (!positionFound && attempts < 100);

            positions[i] = position;
            coinsInRow++;

            if (coinsInRow >= maxCoinsPerRow)
            {
                coinsInRow = 0;
                currentY -= minSpacing;
            }
        }

        return positions;
    }

    private bool IsPositionFree(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, checkRadius);
        return colliders.Length == 1;
    }
}
