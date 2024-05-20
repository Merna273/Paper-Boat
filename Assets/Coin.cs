using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 5f; // Speed of the obstacle
    private ObjectPooling pool; // Reference to the object pool

    public void Initialize(ObjectPooling i_pool)
    {
        pool = i_pool;
    }

    void Start()
    {
        pool = FindObjectOfType<ObjectPooling>();
    }

    void Update()
    {        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        float off_camera = Camera.main.transform.position.x - 100;
        if (transform.position.x < off_camera) // Adjust the boundary as needed
        {
            // Return the object to the pool
            pool.ReturnObjectToPool(this.gameObject);
        }
        
    }
}
