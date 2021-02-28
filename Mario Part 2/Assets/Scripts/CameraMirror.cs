using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMirror : MonoBehaviour
{
    public Transform character;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        // offset gets added to the character's position
        // can set offset to whatever I chose
        Vector3 desiredPosition = character.position + offset;

        // Vector3.Lerp allows me to smoothen the camera follow from one point to another
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // the camera's position gets changed
        transform.position = smoothedPosition;
    }

}
