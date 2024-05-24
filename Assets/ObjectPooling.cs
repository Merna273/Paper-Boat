using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] List<GameObject> MorningPrefab;
    [SerializeField] List<GameObject> NightPrefab;
    [SerializeField] GameObject CoinPrefab = null;
    [SerializeField] GameObject LivesPrefab = null;
    [SerializeField] List<AudioClip> MorningAnimalAudioClips; // List of morning animal audio clips
    [SerializeField] List<AudioClip> NightAnimalAudioClips; // List of night animal audio clips

    [SerializeField] AudioClip CoinAudioClip;
    private AudioSource audioSource;
    int poolSize = 5; // Number of objects to keep in the pool
    private List<GameObject> MorningPool; // List of pooled objects
    private List<GameObject> NightPool;
    private List<GameObject> CoinPool;
    private List<GameObject> LivesPool;

    void Start()
    {
        // Initialize the pool with inactive instances of the prefab
        MorningPool = new List<GameObject>();
        NightPool = new List<GameObject>();
        CoinPool = new List<GameObject>();
        LivesPool = new List<GameObject>();
        audioSource = GetComponent<AudioSource>();

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
        for (int i = 0; i < poolSize; i++)
        {
            if (CoinPrefab != null)
            {
                GameObject obj = Instantiate(CoinPrefab);
                obj.SetActive(false); // Start with inactive objects
                CoinPool.Add(obj);
            }
        }
    }

    public GameObject GetObjectFromMorningPool()
    {
        Debug.Log("Morning Count: " + MorningPool.Count);
        int randomIndex = Random.Range(0, MorningPrefab.Count);
        GameObject newObj = Instantiate(MorningPrefab[randomIndex]);
        // int animalIndex = NightPrefab.FindIndex(x => x.name == NightPrefab[randomIndex].name);
        // animator.SetInteger("AnimalNumber", animalIndex + 1);
        // Debug.Log("Animal Index: " + animalIndex);
        string animalName = MorningPrefab[randomIndex].name; // Extract the name of the prefab's GameObject
        int audioIndex = MorningAnimalAudioClips.FindIndex(x => x.name == animalName); // Find the index of the audio clip based on the prefab's name
        if (audioIndex != -1)
        {
            // Start a coroutine to wait for 2 seconds before playing the sound
            StartCoroutine(PlayDelayedMorningSound(MorningAnimalAudioClips[audioIndex]));
        }
        newObj.SetActive(true);
        MorningPool.Add(newObj);
        return newObj;
    }

    IEnumerator PlayDelayedMorningSound(AudioClip clip)
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds
        audioSource.clip = clip;
        audioSource.Play();
    }

    // Similarly, you can implement a method for the night pool using a coroutine

    public GameObject GetObjectFromNightPool()
    {
        Debug.Log("Night Count: " + NightPool.Count);
        int randomIndex = Random.Range(0, NightPrefab.Count);
        GameObject newObj = Instantiate(NightPrefab[randomIndex]);
        // int animalIndex = NightPrefab.FindIndex(x => x.name == NightPrefab[randomIndex].name);
        // Debug.Log("Animal Index: " + animalIndex);
        // animator.SetInteger("AnimalNumber", animalIndex + 1); // Set the integer parameter of the animator (for animation
        string animalName = NightPrefab[randomIndex].name; // Extract the name of the prefab's GameObject
        int audioIndex = NightAnimalAudioClips.FindIndex(x => x.name == animalName); // Find the index of the audio clip based on the prefab's name
        if (audioIndex != -1)
        {
            // Start a coroutine to wait for 2 seconds before playing the sound
            StartCoroutine(PlayDelayedNightSound(NightAnimalAudioClips[audioIndex]));
        }
        newObj.SetActive(true);
        NightPool.Add(newObj);
        return newObj;
    }

    public GameObject GetObjectFromCoinPool()
    {

        if (CoinPrefab == null)
        {
            return null;
        }
        else
        {

            GameObject newObj = Instantiate(CoinPrefab);
            newObj.SetActive(true);
            CoinPool.Add(newObj);
            return newObj;
        }

    }
    public GameObject GetObjectFromLivesPool()
    {

        if (LivesPrefab == null)
        {
            return null;
        }
        else
        {

            GameObject newObj = Instantiate(LivesPrefab);
            newObj.SetActive(true);
            LivesPool.Add(newObj);
            return newObj;
        }

    }

    IEnumerator PlayDelayedNightSound(AudioClip clip)
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        // Deactivate and return the object to the pool
        obj.SetActive(false);
    }
}
