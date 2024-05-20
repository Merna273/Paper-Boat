using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text scoreText;
    private int score;
    private int HighScore;
    // Start is called before the first frame update
    void Start()
    {

        score = PlayerPrefs.GetInt("Score");
        HighScore = PlayerPrefs.GetInt("HighScore");

        if (score > HighScore)
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
            setnewHighScore(HighScore);
        }
        else
        {
            SetScore(score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void setnewHighScore(int score)
    {
        scoreText.text = "New High Score: " + score.ToString();
    }
}
