using UnityEngine;
using System.Collections;

public class BonusSpawner : MonoBehaviour
{
    public GameObject shieldPrefab; // Префаб щита
    public GameObject magnetPrefab; // Префаб магнита
    private float minSpawnInterval = 10.0f;
    private float maxSpawnInterval = 15.0f;
    private float spawnY = 7.0f;
    private float minX = -2.0f;
    private float maxX = 2.0f;
    private float minSpacing = 1.0f;
    public float checkRadius = 1.0f; // Радиус проверки наличия других объектов

    void Start()
    {
        StartCoroutine(SpawnBonuses());
    }

    private IEnumerator SpawnBonuses()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            int numberOfBonuses = Random.Range(1, 3); // Спавн 1 или 2 бонусов
            Vector2[] positions = GeneratePositions(numberOfBonuses);

            for (int i = 0; i < numberOfBonuses; i++)
            {
                if (IsPositionFree(positions[i]))
                {
                    if (i == 0)
                    {
                        Instantiate(shieldPrefab, new Vector3(positions[i].x, spawnY, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(magnetPrefab, new Vector3(positions[i].x, spawnY, 0.0f), Quaternion.identity);
                    }
                }
            }
        }
    }

    private Vector2[] GeneratePositions(int numberOfBonuses)
    {
        Vector2[] positions = new Vector2[numberOfBonuses];
        bool[] occupied = new bool[5]; // 5 возможных позиций ( -2, -1, 0, 1, 2 )

        for (int i = 0; i < numberOfBonuses; i++)
        {
            Vector2 position;
            bool positionFound = false;
            int attempts = 0;

            do
            {
                float xPos = Mathf.Round(Random.Range(minX, maxX) / minSpacing) * minSpacing;

                int gridIndex = Mathf.RoundToInt((xPos - minX) / minSpacing);

                if (gridIndex >= 0 && gridIndex < 5 && !occupied[gridIndex])
                {
                    occupied[gridIndex] = true;
                    position = new Vector2(xPos, spawnY);
                    positions[i] = position;
                    positionFound = true;
                }
                attempts++;
            } while (!positionFound && attempts < 100);
        }

        return positions;
    }

    private bool IsPositionFree(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, checkRadius);
        return colliders.Length == 1;
    }
}
