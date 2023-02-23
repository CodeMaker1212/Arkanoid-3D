using UnityEngine;

namespace Arkanoid3D
{
    [RequireComponent(typeof(ShakingEffect))]

    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GlobalEvent _onRearPanelCollision;

        private ShakingEffect _shakingEffect;

        private void Awake() => _shakingEffect = GetComponent<ShakingEffect>();

        private void OnEnable() => _onRearPanelCollision.OnPublished += HandleRearPanelCollision;

        private void OnDisable() => _onRearPanelCollision.OnPublished -= HandleRearPanelCollision;

        public void HandleRearPanelCollision() => _shakingEffect.Play();
    }
}