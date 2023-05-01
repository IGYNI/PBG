using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ordering
{
    public class InfoPanel : MonoBehaviour
    {
        public Image SectionColorImage;
        public TMP_Text CarIndex;
        public TMP_Text Description;

        public void Set(Color color, string carIndex, string description)
        {
            gameObject.SetActive(true);
            SectionColorImage.color = color;
            CarIndex.text = "Car : " + carIndex;
            Description.text = description;
        }
    }
}
