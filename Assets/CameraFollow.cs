using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public float rotationSpeed = 100f;

    void Update()
    {
        Vector3 desiredPosition = target.position;
        Vector3 smoothedPOsition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPOsition;

        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * smoothSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.RotateAround(smoothedPOsition, Vector3.up, rotation);

        //Look up/down
        if(Input.GetKey(KeyCode.O)){
            transform.Rotate(-Time.deltaTime*rotationSpeed, 0, 0);
        }
        else if(Input.GetKey(KeyCode.U)){
            transform.Rotate(Time.deltaTime*rotationSpeed,0, 0);
        }
    }
}
