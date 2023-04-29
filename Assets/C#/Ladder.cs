using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject hand;
    public GameObject newParent;

    private bool isRange;

    private void Update()
    {
        if (isRange==true && hand.transform.childCount == 1 && Input.GetKeyDown(KeyCode.E))
        {
            foreach (Transform child in hand.transform)
            {
                child.SetParent(newParent.transform);
                child.gameObject.transform.localPosition = Vector3.zero;
                child.gameObject.transform.localRotation = Quaternion.identity;
            }
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
