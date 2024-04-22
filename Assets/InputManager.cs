using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] Sprite PlaneSprite;
    [SerializeField] Sprite BoatSprite;
    private bool boat_state;
    private SpriteRenderer spriteRenderer; 
    [SerializeField] float minY_boat = 0f;
    [SerializeField] float maxY_boat = 10f;
    [SerializeField] float minY_plane = 0f;
    [SerializeField] float maxY_plane = 10f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boat_state = true;
    }

    // Update is called once per frame
    void Update()
    {
        acquireInputs();
    }

    void acquireInputs()
    {
        // We split acquireInputs into two functions because we like to keep things neat
        acquireAxis();
        acquireButtons();
    }

    void acquireAxis()
    {
                // Get the input from the keyboard
        float verticalInput = 0;

        // Check if the user is pressing the up or down arrow key
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1;
        }

        // Calculate the movement
        if (boat_state)
        {
            Vector3 movement = new Vector3(0, verticalInput * speed * Time.deltaTime, 0);

            // Get the new position
            Vector3 newPosition = transform.position + movement;

            // Clamp the Y position within the bounds
            newPosition.y = Mathf.Clamp(newPosition.y, minY_boat, maxY_boat);

            // Move the object to the clamped position
            transform.position = newPosition;
        }
        else
        {
            Vector3 movement = new Vector3(0, verticalInput * speed * Time.deltaTime, 0);

            // Get the new position
            Vector3 newPosition = transform.position + movement;

            // Clamp the Y position within the bounds
            newPosition.y = Mathf.Clamp(newPosition.y, minY_plane, maxY_plane);

            // Move the object to the clamped position
            transform.position = newPosition;
        }

    }

    void acquireButtons()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Change the sprite to the new sprite
            if (spriteRenderer != null)
            {
                if (boat_state)
                {
                    boat_state = false;
                    spriteRenderer.sprite = PlaneSprite;
                    Vector3 newPosition = transform.position;
                    newPosition.y = 7;
                    transform.position = newPosition;
                }
                else
                {
                    boat_state = true;
                    spriteRenderer.sprite = BoatSprite;
                    Vector3 newPosition = transform.position;
                    newPosition.y = -14;
                    transform.position = newPosition;
                }
            }
        }
    }
}
