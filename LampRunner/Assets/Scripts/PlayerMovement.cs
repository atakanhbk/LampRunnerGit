using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerMovementSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward *Time.deltaTime* playerMovementSpeed;
    }
}
