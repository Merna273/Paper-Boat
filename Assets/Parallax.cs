using UnityEngine;

public class Parallax : MonoBehaviour
{
	private float length, startPos;
	public GameObject cam;
	public float parallaxEffect;

	[SerializeField]
	private float minYOffset = -1.0f; // Minimum y-axis offset
	[SerializeField]
	private float maxYOffset = 1.0f;  // Maximum y-axis offset
	[SerializeField]
	private float yOffsetSpeed = 1.5f; // Speed of y-axis movement

	private float currentYOffset;

	void Start()
	{
		startPos = transform.position.x;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
		currentYOffset = Random.Range(minYOffset, maxYOffset);
	}

	void FixedUpdate()
	{
		float temp = (cam.transform.position.x * (1 - parallaxEffect));
		float dist = (cam.transform.position.x * parallaxEffect);

		// Calculate y-axis movement
		currentYOffset += yOffsetSpeed * Time.deltaTime;
		if (currentYOffset > maxYOffset || currentYOffset < minYOffset)
		{
			yOffsetSpeed *= -1; // Reverse direction if reaching bounds
		}

		float newYPos = transform.position.y + currentYOffset * Time.deltaTime;
		float clampedYPos = Mathf.Clamp(newYPos, Camera.main.ScreenToWorldPoint(Vector3.zero).y, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).y);

		transform.position = new Vector3(startPos + dist, clampedYPos, transform.position.z);

		if (temp > startPos + length) startPos += length;
		else if (temp < startPos - length) startPos -= length;
	}
}
