using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goBackToMainMenu()
    {
        // Time.timeScale = 1;
        int back = PlayerPrefs.GetInt("Back");
        if (back == 1)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (back == 2)
        {
            SceneManager.LoadScene("LosingScene");
        }
    }
}
