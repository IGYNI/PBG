using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public int i;
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

        transform.Rotate(deltaY * -1, deltaX * -1, deltaZ, Space.World);

        _previousMousePosition = Input.mousePosition;
    }

    void Update()
    {
        i++;
        i--;
    }
}

