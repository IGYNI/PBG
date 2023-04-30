using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [SerializeField] private Image[] _stickerPoints;
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;

    public bool IsDefault { get; private set; }
    public BoxInfo Info { get; private set; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetInfo(BoxInfo info)
    {
        Info = info;
        _meshRenderer.material.color = info.Color;
        //_stickerPoints[Random.Range(0, _stickerPoints.Length)].sprite = info.Sticker;
        IsDefault = false;
    }

    public void ResetByDefault()
    {
        IsDefault = true;
        Info = null;
        _rigidbody.isKinematic = false;
        _meshRenderer.material.color = Color.white;
    }
}