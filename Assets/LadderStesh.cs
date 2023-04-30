using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderStesh : MonoBehaviour
{
    public GameObject ladeer1;
    public GameObject ladeer2;

   public bool ActiveLadder()
    {
        if (ladeer1.activeSelf == true||ladeer2.activeSelf==true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
