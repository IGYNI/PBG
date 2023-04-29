using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject hand;
    public GameObject newParent;

    private bool isRange;
    private bool isPickUp;

    private void Start()
    {
        isPickUp = false;
    }
    private void Update()
    {
        if (isRange==true && Input.GetKeyDown(KeyCode.E))
        { 
            isPickUp = !isPickUp;

            newParent.SetActive(isPickUp);
            hand.SetActive(!isPickUp);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRange=false;
        }

    }
}
