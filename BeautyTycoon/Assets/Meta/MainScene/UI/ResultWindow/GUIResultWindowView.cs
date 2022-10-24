using System;
using BT.Core.UI.View;
using Meta.Common.UI.GUITextWithImage;
using UnityEngine;

namespace Meta.MainScene.UI.ResultWindow
{
    public class GUIResultWindowView : UIView
    {
        [SerializeField] private GUITextWithImageView _text;
        [SerializeField] private GUITextWithImageView _clientsProcessed;
        [SerializeField] private GUITextWithImageView _balance;
        [SerializeField] private GUITextWithImageView _reputation;
        [SerializeField] private GUITextWithImageView _rent;
        [SerializeField] private GUITextWithImageView _okButton;
        
        protected override void OnAwake()
        {
#if DEBUG
            Debug.Assert(_text != null);
            Debug.Assert(_clientsProcessed != null);
            Debug.Assert(_reputation != null);
            Debug.Assert(_balance != null);
            Debug.Assert(_rent != null);
            Debug.Assert(_okButton != null);
#endif
        }

        public void Show(
            string mainText, 
            string clientsProcessed, 
            string reputation, 
            string balance, 
            string rent, 
            string okButton, 
            Action okButtonClick 
        )
        {
            _text.ShowText(mainText);
            _clientsProcessed.ShowText(clientsProcessed);
            _reputation.ShowText(reputation);
            _balance.ShowText(balance);
            _rent.ShowText(rent);
            _okButton.ShowText(okButton);
            _okButton.ShowWithAction(okButtonClick);
        }
    }
}
