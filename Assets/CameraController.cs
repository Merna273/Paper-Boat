
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject paper;
    [SerializeField]
    float offset;
    [SerializeField]
    float offsetSmoothing;
    private Vector3 PlayerPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerPosition = new Vector3(paper.transform.position.x, transform.position.y, transform.position.z);


        PlayerPosition = new Vector3(PlayerPosition.x + offset, PlayerPosition.y, PlayerPosition.z);


        transform.position = Vector3.Lerp(transform.position, PlayerPosition, offsetSmoothing * Time.deltaTime);
    }
}
