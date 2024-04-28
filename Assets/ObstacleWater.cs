using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWater : MonoBehaviour
{
    public float speed = 5f; // Speed of the obstacle
    private ObjectPooling pool; // Reference to the object pool
    // public Transform camera; // Reference to the following camera


    public void Initialize(ObjectPooling i_pool)
    {
        pool = i_pool;
    }

    void Start()
    {
        // Get reference to the object pool
        pool = FindObjectOfType<ObjectPooling>();
    }

    void Update()
    {
        // Move the obstacle to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Check if the obstacle is off-screen (e.g., beyond a certain x-coordinate)
        float off_camera = Camera.main.transform.position.x - 100;   
        if (transform.position.x < off_camera) // Adjust the boundary as needed
        {
            // Return the object to the pool
            pool.ReturnObjectToPool(this.gameObject);
        }
    }
}
