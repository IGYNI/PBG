using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Box> ListOfBoxesInPlayerIN;
    public List<Tool> ListOfToolsInInventory;
    public List<Transform> ListOfBeltPos;
    public GameObject Player;
    public Tool InHands;
    public Tool InHandsAnother;

    //public void UpdateSlots()
    //{
    //    if(ListOfToolsInInventory.Count > 0)
    //    {
    //        int k = 0;
    //        for (var i = 0; i < ListOfToolsInInventory.Count; i++)
    //        {
    //            if(k < ListOfToolsInInventory.Count)
    //            {
    //                ListOfToolsInInventory[i].transform.SetParent(Player.transform);
    //                ListOfToolsInInventory[i].transform.position = ListOfBeltPos[k].position;
    //                ListOfToolsInInventory[i].transform.rotation = ListOfBeltPos[k].rotation;
    //                k++;  
    //            }                              
    //        }
    //    }
    //}

    public void TakeOutAll()
    {
        InHands.transform.gameObject.SetActive(false);
        InHandsAnother.transform.gameObject.SetActive(false);
    }
    public void TakeBackAll()
    {
        InHands.transform.gameObject.SetActive(true);
        InHandsAnother.transform.gameObject.SetActive(true);
    }

}
