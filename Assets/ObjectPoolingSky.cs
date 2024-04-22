using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingSky : MonoBehaviour
{
    public List<GameObject> prefab; // The prefab to instantiate
    public int poolSize = 10; // Number of objects to keep in the pool
    private List<GameObject> pool; // List of pooled objects
    public Transform camera; // Reference to the following camera

    void Start()
    {
        // Initialize the pool with inactive instances of the prefab
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, prefab.Count);
            GameObject obj = Instantiate(prefab[randomIndex]);
            obj.SetActive(false); // Start with inactive objects
            pool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        // Find an inactive object in the pool
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true); // Activate it when using
                return obj;
            }
        }

        // If no inactive object is found, create a new one (optional)
        int randomIndex = Random.Range(0, prefab.Count);
        print(prefab.Count);
        GameObject newObj = Instantiate(prefab[randomIndex]);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        // Deactivate and return the object to the pool
        obj.SetActive(false);
    }
}
