using UnityEngine;

public class Parallax : MonoBehaviour
{
	private float length, startPos;
	public GameObject cam;
	public float parallaxEffect;


	void Start()
	{
		startPos = transform.position.x;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	void LateUpdate()
	{
		float temp = (cam.transform.position.x * (1 - parallaxEffect));
		float dist = (cam.transform.position.x * parallaxEffect);

		float ParallaxX = startPos + dist;
		Vector3 pos = transform.position;
		pos.x = ParallaxX;
		transform.position = pos;

		if (temp > startPos + length) startPos += length;
		else if (temp < startPos - length) startPos -= length;
	}
}
