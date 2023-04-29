using UnityEngine;


public class Lighting : MonoBehaviour
{
    [SerializeField] GameObject Light;
    [SerializeField] Collider player;
    private bool isInRange;
 
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Light.SetActive(true);   
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        int random = UnityEngine.Random.Range(1, 101);
        isInRange = true;

    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;

    }
    
}
