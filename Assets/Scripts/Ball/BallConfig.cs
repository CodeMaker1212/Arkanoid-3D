using UnityEngine;

namespace Arkanoid3D
{
    [CreateAssetMenu(fileName = "BallConfig", menuName = "Configs/Ball")]

    public class BallConfig : ScriptableObject
    {
        [SerializeField, Range(0, 0.1f)] private float _startSpeed;
        [SerializeField, Range(0, 20f)] private float _maxSpeed;
        [SerializeField, Range(0, 1f)] private float _acceleration;
        [SerializeField, Range(0, 100.0f)] private float _rotationSpeedMultiplier;
        [SerializeField, Range(0, 20f)] private float _launchingAngle;

        public float StartSpeed => _startSpeed;
        public float MaxSpeed => _maxSpeed;
        public float Acceleration => _acceleration;
        public float RotationSpeedMuliplier => _rotationSpeedMultiplier;
        public float LaunchingAngle => _launchingAngle;
    }
}