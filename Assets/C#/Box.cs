using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [SerializeField] private Image[] _stickerPoints;
    [SerializeField] private TMP_Text _documentText;
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;

    public bool IsDefault => Info == null;
    public BoxInfo Info { get; private set; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();

    }

    public void ResetByDefault()
    {
        if (IsDefault)
            return;

        Info = null;
        _rigidbody.isKinematic = false;
        _meshRenderer.material.color = Color.white;
        _documentText.text = "???";
        _stickerPoints
            .Where(point => point.isActiveAndEnabled).ToList()
            .ForEach(point => point.gameObject.SetActive(false));
    }

    public void SetInfo(BoxInfo info)
    {
        Info = info;
        _meshRenderer.material.color = info.Color;
        _documentText.text = info.Document.Text;
        int randomStartIndex = Random.Range(0, _stickerPoints.Length);

        foreach (Sprite sticker in info.Document.Stickers)
        {
            Image stickerPoint = _stickerPoints[randomStartIndex];
            stickerPoint.sprite = sticker;
            stickerPoint.gameObject.SetActive(true);

            if (randomStartIndex < _stickerPoints.Length - 1)
                randomStartIndex++;
            else
                randomStartIndex = 0;
        }
    }
}