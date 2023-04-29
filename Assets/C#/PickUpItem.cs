using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float Range;
    [SerializeField] Transform Point;
    [SerializeField] LayerMask Layers;
    public GameObject GameObject;

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

    }
    void OnDrawGizmosSelected()
    {
        if (Point == null)
            return;
        Gizmos.DrawWireSphere(Point.position, Range);
    }

}
