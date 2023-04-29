using UnityEngine;

public class Stesh : MonoBehaviour
{
    public int Slot;
    private Ladder _ladder;
    private bool loanin;

    [field: SerializeField] public GameObject LadderView { get; private set; }
    
    private void Start()
    {
        _ladder = FindObjectOfType<Ladder>();

        loanin = true;
        if (_ladder.gameObject.activeSelf == true)
        {
            Slot = 1;
        }
       
        
    }

    private void Update()
    {
        if (_ladder.gameObject.activeSelf == false && loanin == true)
        {
            Slot = 0;
            loanin = false; 
        }
    }
}
