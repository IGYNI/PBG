using UnityEngine;

public class PickUp1 : MonoBehaviour
{
    public float Range;
    [SerializeField] Transform Point;
    [SerializeField] LayerMask Layers;
    [SerializeField] LayerMask Item;
    [SerializeField] Transform hand;
    public GameObject GameObject;
    private bool inhand;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpItems();
        }
    }
    private void PickUpItems()
    {
        Collider[] hit = Physics.OverlapSphere(Point.position, Range, Layers);
        foreach (Collider obj in hit)
        {
            GameObject.SetActive(true);

        }
        Collider[] hits = Physics.OverlapSphere(Point.position, Range, Item);
        foreach (Collider obj in hits)
        {
    
           obj.gameObject.SetActive(true);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (Point == null)
            return;
        Gizmos.DrawWireSphere(Point.position, Range);
    }

}
