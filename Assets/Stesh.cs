using UnityEngine;

public class Stesh : MonoBehaviour
{
    public int Slot;
    public GameObject _ladder;
    private bool loanin;

    [field: SerializeField] public GameObject LadderView { get; private set; }
    
    private void Start()
    {
        

        loanin = true;
        if (_ladder.activeSelf == false)
        {
            Slot = 1;
        }
       
        
    }

    private void Update()
    {
        if (_ladder.activeSelf == true && loanin == true)
        {
            Slot = 0;
            loanin = false; 
        }
    }
}
