using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_Moon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 
    [SerializeField] Sprite sun;
    [SerializeField] Sprite moon;
    private float timer = 0f;
    private float toggleInterval = 5f;
    private float speed = 8f;

    public float targetY = -10f; // Y-coordinate to move down to
    public float originalY; // Original Y-coordinate to move back to
    private bool movingDown = false; // Indicates whether the object is moving down
    private bool movingUp = false; // Indicates whether the object is moving up
    private bool transition;
    private bool morning;
    // Start is called before the first frame update
    void Start()
    {
        morning = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sun;
        originalY = transform.position.y;
        transition = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //print(timer);

        if (timer >= toggleInterval)
        {
            if (transition)
            {
                movingDown = true;
                movingUp = false;
            }
            else
            {
                movingDown = false;
                movingUp = true;
            }
            transition = !transition;

            timer = 0f;
        }  
        if (movingDown)
        {
            // Move down with the specified speed
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            // Check if we've reached or crossed the target Y-coordinate
            if (transform.position.y <= targetY)
            {
                // Once the object reaches the target Y-coordinate, switch sprites and start moving up
                switch_sun();
                movingDown = false;
            }
        }
        if (movingUp)
        {
            // Move up with the specified speed
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            // Check if we've reached the original Y-coordinate
            if (transform.position.y >= originalY)
            {
                // Reset the state to move down again
                movingUp = false;
            }
        }      
    }

    void switch_sun()
    {
        if (morning)
        {
            spriteRenderer.sprite = moon;
            morning = false;
        }
        else
        {
            spriteRenderer.sprite = sun;
            morning = true;
        }
    }
}
