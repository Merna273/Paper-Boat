using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawning : MonoBehaviour
{
    [SerializeField] ObjectPooling pool; // Reference to the object pool

    private DayNight_timer dayNightTimer;
    private int currentIndex = 0;

    [SerializeField] Transform camera; // Reference to the following camera
    float MinSpawnDistance = 50f; // Distance from the camera
    float MaxSpawnDistance = 100f; // Distance from the camera
    [SerializeField] float rangeUp;
    [SerializeField] float rangeDown;
    private int obstaclecount = 0;
    private int coincount = 0;
    [SerializeField] float Obs_spawnInterval = 5f; // Time interval between spawns
    [SerializeField] float Coin_spawnInterval = 5f; // Time interval between spawns
    private float timer;

    void Start()
    {
        // pool = FindObjectOfType<ObjectPooling>(); // Get reference to the object pool
        dayNightTimer = FindObjectOfType<DayNight_timer>();
        currentIndex = dayNightTimer.GetCurrentTime();
        timer = Obs_spawnInterval; // Initialize the timer
    }

    void Update()
    {
        timer -= Time.deltaTime; // Update the timer
        print("obstacle count: " + obstaclecount);
        print("coin count: " + coincount);
        if (timer <= 0f)
        {

            if (ShouldSpawnObstacle())
            {
                SpawnObstacle();
            }
            else{
                SpawnCoin();
            }
        }

        
    }


    bool ShouldSpawnObstacle()
    {

        if (obstaclecount < 5)
        {
            return true;
        }

        return false;
    }

    void SpawnObstacle()
    {
        currentIndex = dayNightTimer.GetCurrentTime();
        float cameraX = camera.position.x;
        float spawnXPosition = cameraX + Random.Range(MinSpawnDistance, MaxSpawnDistance);
        if (currentIndex == 0 || currentIndex == 3)
            {
                GameObject MorningObstacle = pool.GetObjectFromMorningPool();
                if (MorningObstacle != null)
                {
                    MorningObstacle.transform.position = new Vector3(
                    spawnXPosition,
                    Random.Range(rangeDown, rangeUp),
                    0
                );
                }
                obstaclecount++;
                timer = Obs_spawnInterval;
            }
            else if (currentIndex == 1 || currentIndex == 2)
            {
                GameObject NightObstacle = pool.GetObjectFromNightPool();
                if (NightObstacle != null)
                {
                    NightObstacle.transform.position = new Vector3(
                    spawnXPosition,
                    Random.Range(rangeDown, rangeUp),
                    0
                );
                }
                obstaclecount++;
                timer = Obs_spawnInterval;
            }
            
    }

    void SpawnCoin()
    {
        float cameraX = camera.position.x;
        float spawnXPosition = cameraX + MaxSpawnDistance;
        if (coincount < 3)
        {
            GameObject Coin = pool.GetObjectFromCoinPool();
            if (Coin != null)
            {
                Coin.transform.position = new Vector3(
                    spawnXPosition,
                    Random.Range(rangeDown, rangeUp),
                    0
                );
                coincount++;
                timer = Coin_spawnInterval;
            }
            else
            {
                obstaclecount = 0;
            }
            // timer = Coin_spawnInterval;
        }
        else
        {
            coincount = 0;
            obstaclecount = 0;
            timer = Obs_spawnInterval;
        }
    }
}
