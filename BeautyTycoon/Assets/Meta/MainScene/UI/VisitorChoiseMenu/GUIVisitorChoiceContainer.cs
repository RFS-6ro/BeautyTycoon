using System.Collections.Generic;
using Meta.MainScene.UI.VisitorChoseMenu.VisitorChoicePanel;
using UnityEngine;

namespace Meta.MainScene.UI.VisitorChoseMenu
{
    public class GUIVisitorChoiceContainer : MonoBehaviour
    {
        [SerializeField] private GUIVisitorChoiсePanelView _choicePanel;

        private List<GUIVisitorChoiсePanelView> _activePanels;
        private List<GUIVisitorChoiсePanelView> _pooledPanels;
        
        protected void Awake()
        {
            _activePanels = new List<GUIVisitorChoiсePanelView>(3);
            _pooledPanels = new List<GUIVisitorChoiсePanelView>(3);
#if DEBUG
            Debug.Assert(_choicePanel != null);
#endif
            _choicePanel.Deactivate();
        }

        public IList<GUIVisitorChoiсePanelView> Show(int number)
        {
            for (int i = 0; i < number; i++)
            {
                CreateOrEnable();
            }

            return _activePanels.AsReadOnly();
        }

        public void Hide()
        {
            _pooledPanels.AddRange(_activePanels);
            _activePanels.ForEach(panel => panel.Deactivate());
            _activePanels.Clear();
        }

        private GUIVisitorChoiсePanelView CreateOrEnable()
        {
            GUIVisitorChoiсePanelView panel;
            if (_pooledPanels.Count == 0)
            {
                panel = Object.Instantiate(_choicePanel, _choicePanel.transform);
            }
            else
            {
                panel = _pooledPanels[0];
                _pooledPanels.RemoveAt(0);
            }
            
            panel.Activate();
            _activePanels.Add(panel);
            return panel;
        }
    }
}
