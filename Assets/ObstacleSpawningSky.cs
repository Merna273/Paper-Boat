using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawningSky : MonoBehaviour
{
    public float spawnInterval = 2f; // Time between spawns
    [SerializeField] private ObjectPoolingSky pool; // Reference to the object pool
    private float timer;

    public Transform camera; // Reference to the following camera
    public float spawnDistance = 10f; // Distance from the camera

    public float rangeUp;
    public float rangeDown;

    void Start()
    {
        pool = FindObjectOfType<ObjectPoolingSky>(); // Get reference to the object pool
        timer = spawnInterval; // Initialize the timer
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Get an object from the pool and set its position relative to the camera
            GameObject obstacle = pool.GetObjectFromPool();

            ObstacleSky obsSky = obstacle.GetComponent<ObstacleSky>();
            if (obsSky != null)
            {
                obsSky.Initialize(pool);
            }

    

            obstacle.transform.position = new Vector3(
                camera.position.x + spawnDistance,
                Random.Range(rangeDown, rangeUp),
                0
            );

            timer = spawnInterval;
        }
    }
}
