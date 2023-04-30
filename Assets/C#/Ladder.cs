using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject hand;
    public GameObject newParent;
    public BoxCollider BoxCollider;
    private Stesh Stesh;
    private Muv Muv;

    public GameObject PointUp;
    private bool isRange;
    private bool isPickUp;
    private int thisladder = 1;
    private float time = 1f;
    private bool upLadder;

    private void Start()
    {
        isPickUp = false;
        upLadder = true;
        Stesh = FindObjectOfType<Stesh>();
        Muv = FindObjectOfType<Muv>();
    }

    private void Update()
    {
        if (isRange==true && Stesh.Slot != 1  && Input.GetKeyUp(KeyCode.E) && thisladder == 1 && upLadder==true || isRange == true &&Input.GetKeyUp(KeyCode.E) && thisladder == 2&& upLadder == true)
        { 
            isPickUp = !isPickUp;
  
            newParent.SetActive(isPickUp);
            hand.SetActive(!isPickUp);
            if (hand.activeSelf == false)
            {
                Stesh.Slot = 1;
                thisladder = 2;
            }
            else
            {
                Stesh.Slot = 0;
                thisladder = 1;
            }
            
        }
        
        if (isRange&&Input.GetKey(KeyCode.E)&&newParent.activeSelf==true&& Muv.isUp == true)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                upLadder=false;
                Stesh.gameObject.transform.position = PointUp.transform.position;
                Muv.isUp = false;
                Muv.movementBounds = BoxCollider;
            }
            else
            {
                upLadder=true;  
            }
        }
        else
        {
            time = 1f;
        }
        if (Muv.isUp == false && isRange&& Input.GetKeyDown(KeyCode.E))
        {
            Muv.isUp = true;
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
