using System.Collections.Generic;

using BT.Core.UI.View;
using BT.Meta.MainScene.UI.VisitorChoseMenu.VisitorChoicePanel;

using UnityEngine;

namespace BT.Meta.MainScene.UI.VisitorChoseMenu
{
    public class GUIVisitorChoiceMenuView : UIView
    {
        [SerializeField] private GUIVisitorChoiceContainer _container;

        protected override void OnAwake()
        {
#if DEBUG
            Debug.Assert(_container != null);
#endif
        }

        public IList<GUIVisitorChoiсePanelView> Show(int maxChoiceData)
        {
            return _container.Show(maxChoiceData);
        }

        public void Hide()
        {
            _container.Hide();
            Deactivate();
        }
    }
}