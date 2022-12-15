using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float cameraFollowSpeed;


    // Update is called once per frame
    void FixedUpdate()
    {


    
      
            transform.position = Vector3.Lerp(transform.position, target.position + offset, cameraFollowSpeed * Time.deltaTime);
  
    }
}