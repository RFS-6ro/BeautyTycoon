using System;
using UnityEngine;

namespace BT.Core.UI.View
{
    public abstract class UIView : MonoBehaviour
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            OnAwake();
        }

        protected abstract void OnAwake();

        public Transform Transform => _transform;
        
        public int SiblingIndex => _transform.GetSiblingIndex();
		
        public bool IsActive => gameObject.activeSelf;

        public bool IsShown => gameObject.activeInHierarchy && IsActive;
        
        public void Activate() => gameObject.SetActive(true);

        public void Deactivate() => gameObject.SetActive(false);

        public void SetActive(bool isActive) => gameObject.SetActive(isActive);

        public void SetFirstSibling() => _transform.SetAsFirstSibling();

        public void SetLastSibling() => _transform.SetAsLastSibling();

        public void SetSiblingIndex(int index) => _transform.SetSiblingIndex(index);
        
        public void SetParent(Transform parent) => _transform.SetParent(parent);
    }
}
