using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float Range;
    [SerializeField] Transform Point;
    [SerializeField] LayerMask enemyLayers;
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
        Collider[] hit = Physics.OverlapSphere(Point.position, Range, enemyLayers);
        foreach (Collider obj in hit)
        {
          GameObject.SetActive(true);
            Debug.Log("E");
        }

    }
    void OnDrawGizmosSelected()
    {
        if (Point == null)
            return;
        Gizmos.DrawWireSphere(Point.position, Range);
    }
}
