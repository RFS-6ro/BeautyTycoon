using Leopotam.Ecs;
using Meta.Common.UI.Input;
using UnityEngine;

namespace Meta.MainScene.CameraLogic
{
    public class SCameraMovement : IEcsInitSystem, IEcsDestroySystem
    {
        private Camera _camera;
        private PanelTouchInputListener _inputListener;

        private Transform _cameraTransform;

        private const float CAMERA_SPEED_MULTIPLYER = 0.1f;
        
        public void Init()
        {
            _cameraTransform = _camera.transform;
            if (_inputListener != null)
            {
                _inputListener.OnDragEvent += CameraMovement;
            }
        }

        private void CameraMovement(Vector2 delta)
        {
            delta *= CAMERA_SPEED_MULTIPLYER;
            
            Vector3 cameraPosition = _cameraTransform.position;
            cameraPosition.x += delta.x;
            cameraPosition.y += delta.y;
            _cameraTransform.position = cameraPosition;
        }

        public void Destroy()
        {
            if (_inputListener != null)
            {
                _inputListener.OnDragEvent += CameraMovement;
            }
        }
    }
}
