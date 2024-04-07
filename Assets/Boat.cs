using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{

    [SerializeField]
    float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveBoat();
    }
    void MoveBoat()
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
}
