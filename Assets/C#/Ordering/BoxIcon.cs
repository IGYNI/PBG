using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ordering
{
    public class BoxIcon : MonoBehaviour
    {
        public InfoPanel InfoPanel;
        public Button Button;
        public Image Image;
        public TMP_Text CarIndex;
        public string Description;

        private void OnEnable()
        {
            Button.onClick.AddListener(SetInfoPanel);
        }

        private void SetInfoPanel()
        {
            InfoPanel.Set(Image.color, CarIndex.text, Description);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(SetInfoPanel);
        }
    }
}
