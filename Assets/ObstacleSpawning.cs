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
    private int obstaclecount=0;
    private int coincount=0;

    void Start()
    {
        // pool = FindObjectOfType<ObjectPooling>(); // Get reference to the object pool
        dayNightTimer = FindObjectOfType<DayNight_timer>();
        currentIndex = dayNightTimer.GetCurrentTime();
    }

    void Update()
    {
        int Index = dayNightTimer.GetCurrentTime();
        if (currentIndex != Index)
        {
            currentIndex = Index;

            if (obstaclecount <= 3)
            {
                if (currentIndex == 0 || currentIndex == 3)
                {
                    GameObject MorningObstacle = pool.GetObjectFromMorningPool();
                    MorningObstacle.transform.position = new Vector3(
                    camera.position.x + Random.Range(MinSpawnDistance, MaxSpawnDistance),
                    Random.Range(rangeDown, rangeUp),
                    0
                );
                }
                else if (currentIndex == 1 || currentIndex == 2)
                {
                    GameObject NightObstacle = pool.GetObjectFromNightPool();
                    NightObstacle.transform.position = new Vector3(
                    camera.position.x + Random.Range(MinSpawnDistance, MaxSpawnDistance),
                    Random.Range(rangeDown, rangeUp),
                    0
                );
                }
                obstaclecount++;
            }
            else
            {
                if ( coincount <= 5)
                {
                    GameObject Coin = pool.GetObjectFromCoinPool();
                    if (Coin != null)
                    {
                        Coin.transform.position = new Vector3(
                        camera.position.x + Random.Range(MinSpawnDistance, MaxSpawnDistance),
                        Random.Range(rangeDown, rangeUp),
                        0
                    );
                    }
                    else 
                    {
                        obstaclecount = 0;
                    }
                    coincount++;
                }
                else
                {
                    coincount = 0;
                    obstaclecount = 0;
                }
            } 
        }
    }
}
