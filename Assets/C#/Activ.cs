using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activ : MonoBehaviour
{
    public GameObject game;
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            game.SetActive(true);
        }
    }
}
