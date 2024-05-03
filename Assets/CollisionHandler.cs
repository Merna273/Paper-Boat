using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private int flashCount = 3;
    private float flashInterval = 0.15f; // Adjust the interval between flashes
    private SpriteRenderer spriteRenderer;
    private PlayerHealth playerHealth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collided");
        if (collision.gameObject.tag == "Obstacle")
        {
            StartCoroutine(FlashObstacle());
            print("collided with Obstacle");
            playerHealth.TakeDamage(1);
        }
    }

    private IEnumerator FlashObstacle( )
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
