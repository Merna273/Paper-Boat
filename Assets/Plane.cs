using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float gravity = 9.8f; // Gravity acceleration

    private Axis_Movement axisMovement; // Reference to the Axis_Movement script
    private bool arrowUpPressed = false; // Flag to check if the up arrow key is pressed

    [SerializeField] int amountOfWaterDamage; // Speed of the plane

    // Rigidbody2D component reference
    private Rigidbody2D rb;
    [SerializeField] PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        axisMovement = FindObjectOfType<Axis_Movement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (axisMovement.getIsUp())
        {
            arrowUpPressed = true;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
        else
        {
            arrowUpPressed = false;
        }
        //if plane reached minY position then stop moving at the y-axis
        if (transform.position.y <= axisMovement.getMinY())
        {
            //make player lose 
            playerHealth.TakeDamage(amountOfWaterDamage);
            gameObject.SetActive(false);
        }

        print("Plane Update");
        print("axisMovement.getIsUp() = " + axisMovement.getIsUp());
        print("axisMovement.getMinY() = " + axisMovement.getMinY());
        print("transform.position.y = " + transform.position.y);
        print("arrowUpPressed = " + arrowUpPressed);
    }

    void FixedUpdate()
    {
        if (!arrowUpPressed)
        {
            Vector2 gravityForce = new Vector2(0, -gravity * rb.mass);
            rb.AddForce(gravityForce);
        }

    }
}
