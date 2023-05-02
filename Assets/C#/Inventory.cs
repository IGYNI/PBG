using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Box> ListOfBoxesInPlayerIN;
    public List<Tool> ListOfToolsInInventory;
    public List<Transform> ListOfBeltPos;
    public Transform Player;
    public Tool InHands;
    public Tool InHandsAnother;

    public void UpdateSlots()
    {
        if(ListOfToolsInInventory.Count > 0)
        {
            int k = 0;
            foreach (var Tool in ListOfToolsInInventory)
            {
                Tool.transform.SetParent(Player);
                Tool.transform.position = ListOfBeltPos[k].position;
                Tool.transform.rotation = ListOfBeltPos[k].rotation;
                k++;  
            }
            {
                
                                             
            }
        }
    }

    public void TakeOutAll()
    {
        foreach (var Tool in ListOfToolsInInventory)
            {
                Tool.transform.gameObject.SetActive(false);
            }
    }
    public void TakeBackAll()
    {
        foreach (var Tool in ListOfToolsInInventory)
            {
                Tool.transform.gameObject.SetActive(true);
            }
    }

}
