using UnityEngine;

namespace Arkanoid3D
{
    public class HorizontalFollowingToMouse : MonoBehaviour, IMovement
    {
        [SerializeField] private MouseInputHandler _mouseInput;

        private void Update() => Move();
      
        public void Move()
        {
            Vector3 thisLastPosition = transform.position;
            thisLastPosition.x = _mouseInput.GetWorldPosition().x;
            transform.position = thisLastPosition;
        }
    }
}