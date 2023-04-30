using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gates : MonoBehaviour
{
    public Transform topPoint;  
    public float moveSpeed = 1f; 
    public float stopDuration = 1f; 
    public bool openOnStart = false; 

    private Vector3 startPos;
    private Vector3 endPos; 
    private bool isOpen = false; 

    private void Start()
    {
        startPos = transform.position;
        endPos = topPoint.position;

        if (openOnStart)
        {
            Open();
        }
    }
    [Button("Open")]
    public void Open()
    {
        if (!isOpen)
        {
            StartCoroutine(MoveGate(endPos));

            isOpen = true;
        }
    }
    [Button("Close")]
    public void Close()
    {
        if (isOpen)
        {
            StartCoroutine(MoveGate(startPos));

            isOpen = false;
        }
    }

    private IEnumerator MoveGate(Vector3 target)
    {
        float elapsedTime = 0;

        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            
            transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);

           
            elapsedTime += Time.deltaTime;

            
            yield return null;
        }

        
        yield return new WaitForSeconds(stopDuration);

        
    }
}
