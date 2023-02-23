using UnityEngine;

namespace Arkanoid3D
{
    [RequireComponent(typeof(Renderer))]

    public class ColorFlashingEffect : VisualEffect
    {
        [SerializeField] private GlobalEvent _initEvent;
        [SerializeField] private ColorFlashingConfig _config;

        private Renderer _renderer;
        private Color _defaultColor;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();

            _defaultColor = _renderer.material.color;
        }

        private void OnEnable() => _initEvent.OnPublished += Play;

        private void OnDisable() => _initEvent.OnPublished -= Play;

        public override void Play()
        {
            _renderer.material.color = _config.TargetColor;

            Invoke(nameof(ResetColor), _config.Duration);
        }

        private void ResetColor() => _renderer.material.color = _defaultColor;
    }
}