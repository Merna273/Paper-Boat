using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] List<GameObject> MorningPrefab;
    [SerializeField] List<GameObject> NightPrefab;
    int poolSize = 5; // Number of objects to keep in the pool
    private List<GameObject> MorningPool; // List of pooled objects
    private List<GameObject> NightPool;
    [SerializeField] Transform camera; // Reference to the following camera

    void Start()
    {
        // Initialize the pool with inactive instances of the prefab
        MorningPool = new List<GameObject>();
        NightPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, MorningPrefab.Count);
            GameObject obj = Instantiate(MorningPrefab[randomIndex]);
            obj.SetActive(false); // Start with inactive objects
            MorningPool.Add(obj);
        }
        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, NightPrefab.Count);
            GameObject obj = Instantiate(NightPrefab[randomIndex]);
            obj.SetActive(false); // Start with inactive objects
            NightPool.Add(obj);
        }
    }

    public GameObject GetObjectFromMorningPool()
    {
        Debug.Log("Morning Count: " + MorningPool.Count);
        int randomIndex = Random.Range(0, MorningPrefab.Count);
        GameObject newObj = Instantiate(MorningPrefab[randomIndex]);
        newObj.SetActive(true);
        MorningPool.Add(newObj);
        return newObj;
    }
    public GameObject GetObjectFromNightPool()
    {
        Debug.Log("Night Count: " + NightPool.Count);
        int randomIndex = Random.Range(0, NightPrefab.Count);
        GameObject newObj = Instantiate(NightPrefab[randomIndex]);
        newObj.SetActive(true);
        NightPool.Add(newObj);
        return newObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        // Deactivate and return the object to the pool
        obj.SetActive(false);
    }
}
