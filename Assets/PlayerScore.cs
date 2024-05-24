using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public delegate void PlayerEvent(int score);

    public int maxScore = 0;
    private int currentScore;
    public ScoreText scoreText;
    // public ScoreText FinalScoreText;

    void Start()
    {
        currentScore = maxScore;
        // PlayerPrefs.SetInt("HighScore", maxScore);
        // PlayerPrefs.Save();
        // scoreText = FindObjectOfType<ScoreText>();
    }

    public PlayerEvent OnDidUpdateScore = null;

    public void AddScore(int score)
    {
        setScore(currentScore + score);
    }
    public void SubtractScore(int score)
    {
        setScore(currentScore - score);
    }

    void setScore(int i_newScore)
    {
        currentScore = i_newScore;
        scoreText.SetScore(currentScore);
        OnDidUpdateScore?.Invoke(currentScore);
    }

    public bool isHighScore()
    {
        if (currentScore > maxScore)
        {
            maxScore = currentScore;
            return true;
        }
        else
            return false;
    }

    public int getScore()
    {
        return currentScore;
    }

}
