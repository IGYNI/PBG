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

    public void ResetByDefault()
    {
        IsDefault = true;
        _meshRenderer.material.color = Color.white;
    }
}