using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_Moon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 
    [SerializeField] Sprite sun;
    [SerializeField] Sprite moon;
    private DayNight_timer dayNightTimer;
    private int currentIndex = 0;

    private float speed = 8f;

    public float targetY = -10f; // Y-coordinate to move down to
    public float originalY; // Original Y-coordinate to move back to
    private bool movingDown = false; // Indicates whether the object is moving down
    private bool movingUp = false; // Indicates whether the object is moving up
    private bool transition;
    private bool morning;

    void Start()
    {
        morning = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sun;
        originalY = transform.position.y;
        transition = true;
        dayNightTimer = FindObjectOfType<DayNight_timer>();
        currentIndex = dayNightTimer.GetCurrentTime();
    }

    // Update is called once per frame
    void Update()
    {
        int Index = dayNightTimer.GetCurrentTime();
        if (currentIndex != Index)
        {
            currentIndex = Index;
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
        }
        movingSunMoon();
    }

    void movingSunMoon()
    {
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
