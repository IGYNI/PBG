using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [SerializeField] private string[] _stickers;
    [SerializeField] private Canvas[] CanvasSides;
    [SerializeField] private Text TextOfNameBox;
    private string NameOfBox;
    private string CatOfBox;
    
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;

    public bool IsDefault { get; private set; }
    public BoxInfo Info { get; private set; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();

    }

    public void ResetByDefault()
    {
        IsDefault = true;
        Info = null;
        _rigidbody.isKinematic = false;
        _meshRenderer.material.color = Color.white;
    }
    public void SetInfo(BoxInfo info)
    {
        UnityEngine.Debug.Log("старт");
        Info = info;
        _meshRenderer.material.color = info.Color;
        //_stickerPoints[Random.Range(0, _stickerPoints.Length)].sprite = info.Sticker;
        _stickers = info.Stickers;
        foreach (var sticker in _stickers)
        {
            int CanvasSide = Random.Range(0, 4);
            var SideStickersTEMP = CanvasSides[CanvasSide].transform.GetComponent<SideStickers>().StickersOfSide;
            int NumbOfSticker = 0;
            for (var i = 0; i < SideStickersTEMP.Length; i++)
            {
                if(SideStickersTEMP[i].name == sticker)
                {
                    NumbOfSticker = i;
                }
            }
            CanvasSides[CanvasSide].transform.GetComponent<SideStickers>().StickersOfSide[NumbOfSticker].SetActive(true);
            CatOfBox = info.CatOfBox;
            foreach (var cat in GetComponent<ListOfItemsNames>().Categorys)
            {
                if(cat == info.CatOfBox)
                {
                    //Костыль, но ща просто не лезет в голову как правельнее сделать (я пытался сделать через свитч, но там какая-то херня)
                    if(cat == "Weapon")
                    {
                        NameOfBox = GetComponent<ListOfItemsNames>().Weapon[Random.Range(0, GetComponent<ListOfItemsNames>().Weapon.Length)];
                    }
                    if(cat == "Food")
                    {
                        NameOfBox = GetComponent<ListOfItemsNames>().Food[Random.Range(0, GetComponent<ListOfItemsNames>().Food.Length)];
                    }
                    if(cat == "Tools")
                    {
                        NameOfBox = GetComponent<ListOfItemsNames>().Tools[Random.Range(0, GetComponent<ListOfItemsNames>().Tools.Length)];
                    }
                    if(cat == "Clothe")
                    {
                        NameOfBox = GetComponent<ListOfItemsNames>().Clothe[Random.Range(0, GetComponent<ListOfItemsNames>().Clothe.Length)];
                    }
                    if(cat == "Animals")
                    {
                        NameOfBox = GetComponent<ListOfItemsNames>().Animals[Random.Range(0, GetComponent<ListOfItemsNames>().Animals.Length)];
                    }
                }
            UnityEngine.Debug.Log(NameOfBox);
            TextOfNameBox.text = NameOfBox;
            }
        IsDefault = false;
        UnityEngine.Debug.Log("конец");
    }

    
}
}