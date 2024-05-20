using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text scoreText;
    private int Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = PlayerPrefs.GetInt("HighScore");

        SetScore(Score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int score)
    {
        scoreText.text = "Highest Score: " + score.ToString();
    }
}
