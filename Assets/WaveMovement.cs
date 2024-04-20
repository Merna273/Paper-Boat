using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    [SerializeField]
    private float minYOffset = -1.0f; // Minimum y-axis offset
    [SerializeField]
    private float maxYOffset = 1.0f;  // Maximum y-axis offset
    [SerializeField]
    private float yOffsetSpeed = 1.5f; // Speed of y-axis movement

    private float currentYOffset;
    // Start is called before the first frame update
    void Start()
    {
        currentYOffset = Random.Range(minYOffset, maxYOffset);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate y-axis movement
        currentYOffset += yOffsetSpeed * Time.deltaTime;
        if (currentYOffset > maxYOffset || currentYOffset < minYOffset)
        {
            yOffsetSpeed *= -1; // Reverse direction if reaching bounds
        }

        float newYPos = transform.position.y + currentYOffset * Time.deltaTime;
        float clampedYPos = Mathf.Clamp(newYPos, Camera.main.ScreenToWorldPoint(Vector3.zero).y, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).y);

        float WaveMovement = clampedYPos;
        Vector3 pos = transform.position;
        pos.y = WaveMovement;
        transform.position = pos;

    }
}
