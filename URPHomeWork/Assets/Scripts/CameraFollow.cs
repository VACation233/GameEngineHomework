using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        offset=transform.position-target.position;

    }

    
    void LateUpdate()
    {
        Vector3 newCameraPos = target.position + offset;
        transform.position = newCameraPos;
        transform.LookAt(target);
    }
}
