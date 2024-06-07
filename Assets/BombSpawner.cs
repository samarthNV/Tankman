using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public int poolSize = 10;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    private List<GameObject> bombPool = new List<GameObject>();
    private int currentIndex = 0;

    void Start()
    {
        // Create the bomb object pool
        CreateBombPool();

        // Start spawning bombs
        InvokeRepeating("SpawnBomb", Random.Range(minSpawnDelay, maxSpawnDelay), Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    void CreateBombPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            bomb.SetActive(false);
            bombPool.Add(bomb);
        }
    }

    void SpawnBomb()
    {
        // Get the next bomb from the pool
        GameObject nextBomb = bombPool[currentIndex];
        currentIndex = (currentIndex + 1) % poolSize;

        // Reset velocity
        nextBomb.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Calculate random position within the screen bounds
        float randomX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x);
        float randomY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

        // Set the position and activate the bomb
        nextBomb.transform.position = new Vector3(randomX, randomY, 0f);
        nextBomb.SetActive(true);
    }
}
