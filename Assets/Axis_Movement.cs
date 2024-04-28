// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player_Movement : MonoBehaviour
// {
//     private InputManager inputManager;
//     [SerializeField] GameObject BoatObject; // Boat child object
//     [SerializeField] GameObject PlaneObject; // Plane child object
//     [SerializeField] float minY_boat = 0f;
//     [SerializeField] float maxY_boat = 10f;
//     [SerializeField] float minY_plane = 0f;
//     [SerializeField] float maxY_plane = 10f;
//     [SerializeField] float speed = 10f;

//     private GameObject currentVehicle; // Reference to the current active vehicle
//     private bool isBoatState = true; // Initial state as boat
//     private float verticalInput;

//     void Start()
//     {
//         inputManager = FindObjectOfType<InputManager>();

//         // Subscribe to the events
//         if (inputManager != null)
//         {
//             inputManager.OnVerticalAxisChanged += HandleVerticalAxis;
//             inputManager.OnSpacePressed += HandleSpacePress;
//         }

//         // Ensure the boat is active initially and the plane is inactive
//         BoatObject.SetActive(true);
//         PlaneObject.SetActive(false);
//         currentVehicle = BoatObject; // Start with the boat as the current vehicle
//     }

//     void Update()
//     {
//         Moveobject();
//     }

//     void Moveobject()
//     {
//         float deltaX = speed * Time.deltaTime;
//         Vector3 deltaPosition = new Vector3(deltaX, 0f, 0f);

//         // Implement the move code for your car
//         move(deltaPosition);
//     }

//     void move(Vector3 i_deltaPosition)
//     {
//         // implement the move code for you car
//         transform.position += i_deltaPosition;
//     }

//     void OnDestroy()
//     {
//         // Unsubscribe from the events to avoid memory leaks
//         if (inputManager != null)
//         {
//             inputManager.OnVerticalAxisChanged -= HandleVerticalAxis;
//             inputManager.OnSpacePressed -= HandleSpacePress;
//         }
//     }

//     void HandleVerticalAxis(float value)
//     {
//         if (isBoatState)
//         {
//             // Calculate the new position for the boat and clamp it within its bounds
//             Vector3 newPosition = currentVehicle.transform.position + new Vector3(0, value, 0);
//             newPosition.y = Mathf.Clamp(newPosition.y, minY_boat, maxY_boat);
//             currentVehicle.transform.position = newPosition;
//         }
//         else
//         {
//             // Calculate the new position for the plane and clamp it within its bounds
//             Vector3 newPosition = currentVehicle.transform.position + new Vector3(0, value, 0);
//             newPosition.y = Mathf.Clamp(newPosition.y, minY_plane, maxY_plane);
//             currentVehicle.transform.position = newPosition;
//         }
//     }

//     void HandleSpacePress()
//     {
//             // Toggle between boat and plane states
//         if (isBoatState)
//         {
//             isBoatState = false;
//             BoatObject.SetActive(false); // Deactivate the boat
//             PlaneObject.SetActive(true); // Activate the plane
//             currentVehicle = PlaneObject; // Set the plane as the current vehicle
//         }
//         else
//         {
//             isBoatState = true;
//             PlaneObject.SetActive(false); // Deactivate the plane
//             BoatObject.SetActive(true); // Activate the boat
//             currentVehicle = BoatObject; // Set the boat as the current vehicle
//         }
//     }

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis_Movement : MonoBehaviour
{
    private InputManager inputManager;

    private bool isUp = false;

    private bool planeFell = false;
    [SerializeField] float minY = 0f;
    [SerializeField] float maxY = 10f;

    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();

        // Subscribe to the events
        if (inputManager != null)
        {
            inputManager.OnVerticalAxisChanged += HandleVerticalAxis;
        }

    }


    void OnDestroy()
    {
        // Unsubscribe from the events to avoid memory leaks
        if (inputManager != null)
        {
            inputManager.OnVerticalAxisChanged -= HandleVerticalAxis;
        }
    }

    void HandleVerticalAxis(float value)
    {
        if (value > 0)
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }

        Vector3 newPosition = transform.position + new Vector3(0, value, 0);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
    }
    public bool getIsUp()
    {
        return isUp;
    }
    public float getMinY()
    {
        return minY;
    }
    public void setPlaneFell(bool value)
    {
        planeFell = value;
    }

}

