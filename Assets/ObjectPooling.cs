using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] List<GameObject> MorningPrefab;
    [SerializeField] List<GameObject> NightPrefab;
    [SerializeField] List<AudioClip> MorningAnimalAudioClips; // List of morning animal audio clips
    [SerializeField] List<AudioClip> NightAnimalAudioClips; // List of night animal audio clips
    private AudioSource audioSource;
    int poolSize = 5; // Number of objects to keep in the pool
    private List<GameObject> MorningPool; // List of pooled objects
    private List<GameObject> NightPool;

    void Start()
    {
        // Initialize the pool with inactive instances of the prefab
        MorningPool = new List<GameObject>();
        NightPool = new List<GameObject>();
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
    }

    public GameObject GetObjectFromMorningPool()
    {
        Debug.Log("Morning Count: " + MorningPool.Count);
        int randomIndex = Random.Range(0, MorningPrefab.Count);
        GameObject newObj = Instantiate(MorningPrefab[randomIndex]);
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
