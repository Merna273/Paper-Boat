using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private InputManager inputManager;
    [SerializeField] GameObject BoatObject; // Boat child object
    [SerializeField] GameObject PlaneObject; // Plane child object
    //audio
    [SerializeField] AudioClip transformSound;
    AudioSource audioSource;
    [SerializeField] PlayerScore PlayerScore;
    private float timer;

    [SerializeField] Animator animator_boat;
    [SerializeField] Animator animator_plane;
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        audioSource = GetComponent<AudioSource>();
        

        // Subscribe to the events
        if (inputManager != null)
        {
            inputManager.OnSpacePressed += HandleSpacePress;
        }

        // Ensure the boat is active initially and the plane is inactive
        BoatObject.SetActive(true);
        PlaneObject.SetActive(false);
        timer = 1f; // Initialize the timer
    }

    // Update is called once per frame
    void Update()
    {
        Moveobject();
         timer -= Time.deltaTime; // Update the timer
        if (timer <= 0f)
        {
            PlayerScore.AddScore(1);
            timer = 1f; // Reset the timer
        }
    }
    void Moveobject()
    {
        float deltaX = speed * Time.deltaTime;
        Vector3 deltaPosition = new Vector3(deltaX, 0f, 0f);

        // Implement the move code for your car
        move(deltaPosition);
    }

    void move(Vector3 i_deltaPosition)
    {
        // implement the move code for you car
        transform.position += i_deltaPosition;
    }

    void OnDestroy()
    {
        // Unsubscribe from the events to avoid memory leaks
        if (inputManager != null)
        {
            inputManager.OnSpacePressed -= HandleSpacePress;
        }
    }

    private bool isBoatState => BoatObject.activeSelf;

    void HandleSpacePress()
    {
        //play the sound
        audioSource.clip = transformSound;
        audioSource.Play();
        // Toggle between boat and plane states
        if (isBoatState)
        {
            // animator_boat.SetBool("TO_Plane", true);
            BoatObject.SetActive(false); // Deactivate the boat
            PlaneObject.SetActive(true); // Activate the plane
        }
        else
        {
            // animator_plane.SetBool("TO_Boat", true);
            PlaneObject.SetActive(false); // Deactivate the plane
            BoatObject.SetActive(true); // Activate the boat
        }
    }
}
