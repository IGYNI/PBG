using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f;

    private Vector3 _previousMousePosition;

    private void OnMouseDown()
    {
        _previousMousePosition = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 deltaMousePosition = Input.mousePosition - _previousMousePosition;

        float deltaX = deltaMousePosition.x * rotationSpeed * Time.deltaTime;
        float deltaY = -deltaMousePosition.y * rotationSpeed * Time.deltaTime; 
        float deltaZ = 0f; 

        transform.Rotate(deltaY, deltaX, deltaZ, Space.World);

        _previousMousePosition = Input.mousePosition;
    }
}
