using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public delegate void PlayerEvent(int i_health);
    public PlayerScore playerScore;
    public int maxHealth = 5;
    private int currentHealth;
    private HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
    }

    public PlayerEvent OnDidUpdateHealth = null;

    public void TakeDamage(int damage)
    {
        setHealth(currentHealth - damage);

        print("Player health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
            StopGame();
        }
    }

    public void heal(int healAmount)
    {
        setHealth(currentHealth + healAmount);
    }

    void setHealth(int i_newHealth)
    {
        i_newHealth = Mathf.Clamp(i_newHealth, 0, maxHealth);
        if (currentHealth == i_newHealth) return;

        currentHealth = i_newHealth;
        healthBar.SetHealth(currentHealth);
        OnDidUpdateHealth?.Invoke(currentHealth);
    }

    void StopGame()
    {
        // Stop the game by setting timeScale to 0
        print (playerScore.getScore());
        PlayerPrefs.SetInt("Score", playerScore.getScore());
        PlayerPrefs.Save();
        SceneManager.LoadScene("LosingScene");
    }


}
