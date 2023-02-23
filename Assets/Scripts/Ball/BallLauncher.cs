using UnityEngine;

namespace Arkanoid3D
{
    public class BallLauncher : MonoBehaviour
    {
        [SerializeField] private MouseInputHandler _mouseInput;
        [SerializeField] private Rolling _ballRolling;

        private void OnEnable() => _mouseInput.OnClick += HandleMouseClick;

        private void OnDisable() => _mouseInput.OnClick -= HandleMouseClick;

        private void HandleMouseClick()
        {
            _ballRolling.enabled = true;

            enabled = false;
        }
    }
}