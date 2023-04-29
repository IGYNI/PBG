using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadingScreen : FadeScreen<LoadingScreen>
    {
        [SerializeField] private Slider _slider;

        public void SetProgress(float progress) => _slider.value = progress;
    }
}
