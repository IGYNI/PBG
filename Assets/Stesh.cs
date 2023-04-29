using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stesh : MonoBehaviour
{
    public int Slot;
    public GameObject Ladder;

    private bool loanin;
    
    private void Start()
    {
        loanin = true;
        if (Ladder.activeSelf == true)
        {
         Slot = 1;
        }
       
        
    }

    private void Update()
    {
        if (Ladder.activeSelf == false&&loanin==true)
        {
            Slot = 0;
            loanin = false; 
        }
    }


}
