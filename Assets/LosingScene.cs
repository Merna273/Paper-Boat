using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingScene : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        int lost= PlayerPrefs.GetInt("playerLost");
        if (lost == 1)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
            PlayerPrefs.SetInt("playerLost", 1);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
