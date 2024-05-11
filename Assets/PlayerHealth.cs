using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    private HealthBar healthBar;
    [SerializeField] AudioClip deathSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        print("Player health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
            //play audio
            audioSource.clip = deathSound;
            audioSource.Play();
            StopGame();
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    public void heal(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    void StopGame()
    {
        // Stop the game by setting timeScale to 0
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
