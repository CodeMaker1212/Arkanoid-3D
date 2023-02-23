using UnityEngine;

namespace Arkanoid3D
{
    public class HorizontalPositionConstrainter : MonoBehaviour
    {
        [SerializeField] private float _leftBound;
        [SerializeField] private float _rightBound;

        private void LateUpdate() => Constraint();

        private void Constraint()
        {
            var lastPosition = transform.position;

            if (lastPosition.x < _leftBound)                 
                lastPosition.x = _leftBound;
            
            else if (lastPosition.x > _rightBound)        
                lastPosition.x = _rightBound;
            
            transform.position = lastPosition;
        }
    }
}