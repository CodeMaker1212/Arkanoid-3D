using UnityEngine;

namespace Arkanoid3D
{
    public class ShakingEffect : VisualEffect
    {
        private const float FORCE = 0.5f;
        private const float DURATION = 0.2f;
        private Vector3 _initialPosition;

        private void OnEnable()
        {
            _initialPosition = gameObject.transform.position;
        }

        private void OnDisable()
        {
            gameObject.transform.position = _initialPosition;
        }

        private void Update()
        {
            transform.position = _initialPosition + (Random.insideUnitSphere * FORCE);
        }

        public override void Play()
        {
            enabled = true;

            Invoke(nameof(Stop), DURATION);
        }

        private void Stop() => enabled = false;      
    }
}