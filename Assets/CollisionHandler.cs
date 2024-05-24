using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private int flashCount = 3;
    private float flashInterval = 0.15f; // Adjust the interval between flashes

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerScore PlayerScore;

    [SerializeField] AudioClip coinAudioClip;
    [SerializeField] AudioClip LivesAudioClip;
    AudioSource audioSource;
    private DayNight_timer dayNightTimer;
    private int currentIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dayNightTimer = FindObjectOfType<DayNight_timer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentIndex = dayNightTimer.GetCurrentTime();
        print("collided");
        if (collision.gameObject.tag == "Obstacle")
        {
            //if morning, player looses 10 from score
            if (currentIndex == 0 || currentIndex == 1)
            {
                StartCoroutine(flashPlayer());
                print("collided with Obstacle");
                PlayerScore.SubtractScore(10);
            }
            else if (currentIndex == 2 || currentIndex == 3)
            {
                //if night, player looses 1 from health
                StartCoroutine(flashPlayer());
                print("collided with Obstacle");
                playerHealth.TakeDamage(1);
            }
        }
        else if (collision.gameObject.tag == "Collectible")
        {
            //make the gameObject disappear
            collision.gameObject.SetActive(false);
            audioSource.PlayOneShot(coinAudioClip);
            PlayerScore.AddScore(5);
        }
        else if (collision.gameObject.tag == "Lives")
        {
            // if in the morning, player gains 2 health
            if (currentIndex == 0 || currentIndex == 1)
            {
                collision.gameObject.SetActive(false);
                audioSource.PlayOneShot(LivesAudioClip);
                playerHealth.heal(2);
            }
            else if (currentIndex == 2 || currentIndex == 3)
            {
                //if in the night, player gains 1 health
                collision.gameObject.SetActive(false);
                audioSource.PlayOneShot(coinAudioClip);
                playerHealth.heal(1);
            }
        }
    }

    private IEnumerator flashPlayer()
    {

        for (int i = 0; i < flashCount; i++)
        {
            // Make the player object disappear and reappear
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashInterval);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(flashInterval);
        }
    }


}
