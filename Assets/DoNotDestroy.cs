using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    static DoNotDestroy instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Check if this is the initial scene (main menu)
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
        {
            // Stop any audio that might be playing
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        //get audio volume from player prefs and set it
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
