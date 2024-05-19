using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //make sure music is playing with the volume of the player pereference

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadGame()
    {
        // Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
