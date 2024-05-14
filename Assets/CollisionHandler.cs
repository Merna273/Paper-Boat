using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private int flashCount = 3;
    private float flashInterval = 0.15f; // Adjust the interval between flashes

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerHealth playerHealth;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collided");
        if (collision.gameObject.tag == "Obstacle")
        {
            StartCoroutine(flashPlayer());
            print("collided with Obstacle");
            playerHealth.TakeDamage(1);
        }
        else if (collision.gameObject.tag == "Collectible")
        {
            // do positive stuff
        }
    }

    private IEnumerator flashPlayer( )
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
