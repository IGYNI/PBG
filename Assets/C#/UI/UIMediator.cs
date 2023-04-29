using General;
using System.Linq;
using UnityEngine;

namespace UI
{
    [DisallowMultipleComponent]
    public class UIMediator : SceneSingletone<UIMediator>
    {
        [SerializeField] private UIElement[] _hud, _popups;

        public UIElement OpenedPopup { get; private set; }

        #region HUD
        public void ShowHUD() => _hud
            .Where(element => element.IsActive() == false).ToList()
            .ForEach(element => element.Show());

        public void ShowHUD<T>() where T : UIElement
        {
            if (TryGetElement(_hud, out T element) && element.IsActive() == false)
                element.Show();
        }

        public void HideHUD() => _hud
            .Where(element => element.IsActive()).ToList()
            .ForEach(element => element.Hide());

        public void HideHUD<T>() where T : UIElement
        {
            if (TryGetElement(_hud, out T element) && element.IsActive())
                element.Hide();
        }
        #endregion

        #region Popups
        public void ShowPopup<T>() where T : UIElement
        {
            if (TryGetElement(_popups, out T element))
            {
                HidePopup();
                OpenedPopup = element;
                OpenedPopup.Show();
            }
        }

        public void HidePopup()
        {
            if (OpenedPopup)
            {
                OpenedPopup.Hide();
                OpenedPopup = null;
            }
        }
        #endregion

        private bool TryGetElement<T>(UIElement[] array, out T element) where T : UIElement
        {
            element = (T)array.SingleOrDefault(element => element is T);
            return element != null;
        }
    }
}
