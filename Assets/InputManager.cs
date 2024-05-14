using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void AxisInputDelegate(float value);
    public event AxisInputDelegate OnVerticalAxisChanged;

    public delegate void ButtonInputDelegate();
    public event ButtonInputDelegate OnSpacePressed;

    private float verticalInput;

    [SerializeField] float speed = 5.0f;

    void Update()
    {
        acquireInputs();
    }

    void acquireInputs()
    {
        acquireAxis();
        acquireButtons();
    }

    void acquireAxis()
    {
        float newVerticalInput = Input.GetAxis("Vertical");

        // Check if the value has changed to avoid unnecessary event triggers
        // if (newVerticalInput != verticalInput)
        // {
        //     verticalInput = newVerticalInput;
        //     OnVerticalAxisChanged?.Invoke(verticalInput * speed * Time.deltaTime);
        // }
        verticalInput = newVerticalInput;
        OnVerticalAxisChanged?.Invoke(verticalInput * speed * Time.deltaTime);
    }

    void acquireButtons()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }
    }
}
