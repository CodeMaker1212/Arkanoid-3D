using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid3D
{
    [CreateAssetMenu(fileName = "NewColorFlashingEffectConfig", menuName = "Configs/Color Flashing Effect")]

    public class ColorFlashingConfig : ScriptableObject
    {
        [SerializeField] private Color _targetColor;
        [SerializeField, Range(0, 0.5f)] private float _duration;

        public Color TargetColor => _targetColor;
        public float Duration => _duration;
    }
}