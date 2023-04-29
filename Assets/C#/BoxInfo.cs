using System.Collections.Generic;
using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    public List<Color> ListColor;

    void Awake()
    {
        ListColor.Add(new UnityEngine.Vector4(0, 255, 0, 255));
        ListColor.Add(new UnityEngine.Vector4(255, 0, 0, 255));
        ListColor.Add(new UnityEngine.Vector4(0, 0, 255, 255));
    }

    public void BoxRefresh()
    {
        GetComponent<Renderer>().material.color = ListColor[Random.Range(0, ListColor.Count)];
    }
} 


