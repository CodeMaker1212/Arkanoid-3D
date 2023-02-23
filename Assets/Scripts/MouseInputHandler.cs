using System;
using UnityEngine;
using static UnityEngine.Input;

namespace Arkanoid3D
{
    public class MouseInputHandler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public event Action OnClick;

        private void Update()
        {
            if (GetMouseButton(0)) OnClick?.Invoke();
        }

        public Vector3 GetWorldPosition()
        {
            Vector3 currentPosition = mousePosition;
            currentPosition.z = -_camera.transform.position.z;
            return _camera.ScreenToWorldPoint(currentPosition);
        }     
    }
}