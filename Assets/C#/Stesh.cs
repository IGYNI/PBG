using UnityEngine;

public class Stesh : MonoBehaviour
{
    public int Slot;
    public GameObject _ladder;
    public GameObject _ladderinPlayer;
    public bool loanin;


    [field: SerializeField] public GameObject LadderView { get; private set; }
    
    private void Start()
    {
        
        loanin = true;
        if (_ladder.activeSelf == true)
        {
            Slot = 1;
        }
       
        
    }

    private void Update()
    {
        if (_ladder.activeSelf == false&&loanin==true)
        {
            Slot = 0;
           loanin = false;
        }
        if (Input.GetKeyDown(KeyCode.G)&& Slot==0)
        {
            _ladder.transform.position = _ladderinPlayer.transform.position;
            _ladder.SetActive(true);
            _ladderinPlayer.SetActive(false);
            loanin = true;
            Slot = 1;
        }
    }
}
