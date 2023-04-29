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
    public Transform hitbox = null;
    public List<Box> ListOfBoxesInPlayer;
    public Transform _lastposBox;

    void Update()
    {
        
        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mRay, out RaycastHit hitInfo))
        {
            //if (hitbox.GetComponent<Box>())
            //        hitbox.GetComponent<Outline>().OutlineWidth = 2;
            //if (!hitInfo.transform.GetComponent<Box>())
            //        hitbox.GetComponent<Outline>().OutlineWidth = 0;
            //hitbox = hitInfo.transform;
            if(Input.GetMouseButtonDown(0))
            {
                
                if (Point == null)
                    return;
                if (hitInfo.transform.TryGetComponent(out Box box))
                {
                    if (UnityEngine.Vector3.Distance(hitInfo.transform.position, GetComponent<Transform>().position) < 5)
                    {
                    _currentBox = box;
                    TpToCameraObjetc(hitInfo.transform);
                    }
                }
            }
        }
    }

    public void TpToCameraObjetc(Transform obj)
    {
        _lastposBox = _currentBox.transform;
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
            float hight = 0;
            foreach (var box in ListOfBoxesInPlayer)
            {
                hight += box.transform.GetComponent<Transform>().localScale.y / 50;
            }
            hight += _currentBox.transform.GetComponent<Transform>().localScale.y  / 50;
            _currentBox.transform.position = PositionWithPlayer.position + new UnityEngine.Vector3(0, hight, 0);
            UnityEngine.Debug.Log("hui");
            _currentBox.transform.rotation =  PositionWithPlayer.rotation; //UnityEngine.Quaternion.Euler(PlayerRotationn.x, PlayerRotationn.y, PlayerRotationn.z);
            bool Wasnt = true;
            foreach (var box in ListOfBoxesInPlayer)
            {
                if (box == _currentBox)
                    Wasnt = false;
            }
            if (Wasnt)
            {
                ListOfBoxesInPlayer.Add(_currentBox);
                GetComponent<Inventory>().ListOfBoxesInPlayerIN.Add(_currentBox);
            }

           
        }
    }

    public void OutBox()
    {
        _currentBox.transform.SetParent(null);
        _currentBox.transform.position = GetComponent<Transform>().position + new UnityEngine.Vector3(1, 1, 1);
        _currentBox.transform.rotation = PositionWithPlayer.rotation;
        foreach (var box in ListOfBoxesInPlayer)
            {
                if (box == _currentBox)
                {
                    ListOfBoxesInPlayer.Remove(box);
                    GetComponent<Inventory>().ListOfBoxesInPlayerIN.Remove(box);
                }
            }
        
    }


}
