using DG.Tweening;
using General;
using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class FadeScreen<T> : ProjectSingleton<T> where T: Component
    {
        [SerializeField] protected CanvasGroup _canvasGroup;
        [SerializeField, Range(0, 5)] private float _fadeInDuration, _fadeOutDuration;

        [field: SerializeField] public Camera Camera { get; private set; }

        public void FadeIn(Action callback = null) => StartCoroutine(Fade(0, 1, _fadeInDuration, callback));

        public void FadeOut(Action callback = null) => StartCoroutine(Fade(1, 0, _fadeOutDuration, callback));

        private IEnumerator Fade(float startValue, float endValue, float duration = 0, Action callback = null)
        {
            DOTween.Kill(_canvasGroup);
            _canvasGroup.alpha = startValue;
            yield return _canvasGroup.DOFade(endValue, duration).WaitForCompletion();
            callback?.Invoke();
        }
    }
}
