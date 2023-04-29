using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public float Range;
    [SerializeField] Transform Point;
    [SerializeField] LayerMask Layers;
    public Transform PositionWithCamera;
    public Transform PositionWithPlayer;
    public GameObject GameObject;
    public GameObject TakeBoxBtn;
    public Box _currentBox; 

    public List<GameObject> ListOfBoxesInPlayer;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mRay, out RaycastHit hitInfo, 100))
            {
                if (Point == null)
                    return;

                if (hitInfo.transform.TryGetComponent(out Box box))
                {
                    _currentBox = box;
                    TpToCameraObjetc(hitInfo.transform);
                }
            }
        }
    }

    public void TpToCameraObjetc(Transform obj)
    {
        _currentBox.transform.SetParent(Camera.main.transform);
        _currentBox.transform.position = PositionWithCamera.position;
        TakeBoxBtn.SetActive(true);
        _currentBox.GetComponent<RotateObject>().enabled = true;
    } 
    public void TakeBox()
    {
        if(ListOfBoxesInPlayer.Count < 3)   
        {
            TakeBoxBtn.SetActive(false);
            _currentBox.transform.SetParent(GetComponent<Transform>());
            UnityEngine.Vector3 PlayerRotationn = new UnityEngine.Vector3(GetComponent<Transform>().rotation.x, GetComponent<Transform>().rotation.y, GetComponent<Transform>().rotation.z) + new UnityEngine.Vector3(-90, 90, 0);
            _currentBox.transform.position = PositionWithPlayer.position;
             UnityEngine.Debug.Log("hui");
            _currentBox.transform.rotation =  PositionWithPlayer.rotation; //UnityEngine.Quaternion.Euler(PlayerRotationn.x, PlayerRotationn.y, PlayerRotationn.z);

           
        }
    }
}
