using UnityEngine;

public class Ladder : MonoBehaviour
{
    private GameObject hand;
    public GameObject newParent;
    private Stesh Stesh;
   

    private bool isRange;
    private bool isPickUp;
    private int thisladder = 1;

    private void Start()
    {
        isPickUp = false;
        Stesh = FindObjectOfType<Stesh>();
        hand = Stesh.LadderView.gameObject;
    }

    private void Update()
    {
        if (isRange==true && Stesh.Slot != 1  && Input.GetKeyDown(KeyCode.E) && thisladder == 1 || isRange == true &&Input.GetKeyDown(KeyCode.E) && thisladder == 2)
        { 
            isPickUp = !isPickUp;
  
            newParent.SetActive(isPickUp);
            hand.SetActive(!isPickUp);
            if (hand.activeSelf == false)
            {
                Stesh.Slot = 1;
                thisladder = 2;
                Debug.Log("Work");
            }
            else
            {
                Stesh.Slot = 0;
                thisladder = 1;
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
