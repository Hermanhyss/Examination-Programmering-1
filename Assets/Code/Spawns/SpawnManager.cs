using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxSpawnCount = 10; // Set the maximum number of spawns

    private int currentSpawnCount = 0;

    public float verticalSpeed = 1f;
    public float amplitude = 5f; // Set the amplitude of the sinusoidal motion
    public float maxY = 10f; // Set the maximum Y-axis position
    public float minY = -10f; // Set the minimum Y-axis position

    private float timeCounter = 0f;

    void Start()
    {
        // Start spawning enemies at intervals
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void Update()
    {
        MoveSpawnPointSinusoidally();
    }

    void SpawnEnemy()
    {
        // Check if the maximum spawn count has been reached
        if (currentSpawnCount >= maxSpawnCount)
        {
            // Stop spawning if the limit is reached
            CancelInvoke("SpawnEnemy");
            return;
        }

        // Instantiate the enemy at the spawn point
        _ = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Increment the spawn count
        currentSpawnCount++;
    }

    void MoveSpawnPointSinusoidally()
    {
        // Calculate the new Y position based on sinusoidal motion
        float newY = Mathf.Sin(timeCounter) * amplitude;

        // Clamp the Y position within the specified range
        newY = Mathf.Clamp(newY, minY, maxY);

        // Update the spawn point position
        transform.position = new Vector3(transform.position.x, newY, 0f);

        // Increment the time counter based on vertical speed
        timeCounter += verticalSpeed * Time.deltaTime;
    }
}

