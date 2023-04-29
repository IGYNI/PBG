using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBox : MonoBehaviour
{
    public GameObject button;
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            button.SetActive(true);
        }
    }
}
