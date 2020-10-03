using UnityEngine;

/// <summary> Class for the camera's control <summary> 
public class CameraFollow : MonoBehaviour
{
    public GameObject CameraFollowObj;

    public float CameraMoveSpeed = 120.0f;

    private Vector3 StartingPosition;

    void Start()
    {
        StartingPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Transform target = CameraFollowObj.transform;
            
            float step = CameraMoveSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.position = StartingPosition;
        }
    }

}
