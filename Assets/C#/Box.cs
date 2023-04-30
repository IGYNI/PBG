using UnityEngine;

public class Box : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    public bool IsDefault { get; private set; }
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetInfo(BoxInfo info)
    {
        _meshRenderer.material.color = info.Color;
        IsDefault = false;
    }
<<<<<<< HEAD
=======

    public void ResetByDefault()
    {
        IsDefault = true;
        _meshRenderer.material.color = Color.white;
    }
>>>>>>> c1adc14c91c5bef2f298b12c52325220d0deddd4
}