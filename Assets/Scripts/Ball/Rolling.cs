using UnityEngine;
using static UnityEngine.Random;
using static Arkanoid3D.TagsContainer;

namespace Arkanoid3D
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]

    public class Rolling : MonoBehaviour, IMovement
    {
        [SerializeField] private BallConfig _config;
        [SerializeField] private Transform _body;
        [SerializeField] private GlobalEvent _onBatCollision;
        [SerializeField] private GlobalEvent _onRearPanelCollision;

        private Rigidbody _rigidbody;
        private float _currentSpeed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _currentSpeed = _config.StartSpeed;

            SetRandomStartDirection();
        }

        private void FixedUpdate() => Move();

        private void LateUpdate()
        {                   
            Spin();
            UpdateSpeed();
        }      

        private void SetRandomStartDirection()
        {
            int rndmValue = Range(0, 2);

            float yAngleDelta = rndmValue == 0 ? _config.LaunchingAngle : -_config.LaunchingAngle;

            transform.localEulerAngles =
                new Vector3(transform.localEulerAngles.x,
                            transform.localEulerAngles.y + yAngleDelta,
                            transform.localEulerAngles.z);
        }

        public void Move()
        {
            Vector3 movement = transform.TransformDirection(Vector3.forward) * _currentSpeed;
            _rigidbody.MovePosition(transform.position + movement * Time.deltaTime);
        }

        private void Spin()
        {
            _body.Rotate(-Vector3.up, _currentSpeed * _config.RotationSpeedMuliplier * Time.deltaTime);
        }

        private void UpdateSpeed()
        {
            _currentSpeed =
                Mathf.Clamp(_currentSpeed += _config.Acceleration,
                            _currentSpeed, _config.MaxSpeed);
        }          

        private void OnCollisionEnter(Collision collision)
        {
            ChangeMovementDirection(collision.contacts[0]);

            var collisionTag = collision.gameObject.tag;

            if (collisionTag == RearPanelTag)
                _onRearPanelCollision.Publish();

            else if (collisionTag == BatTag)
                _onBatCollision.Publish();           
        }

        private void ChangeMovementDirection(ContactPoint contactPoint)
        {
            var currentDirection = transform.TransformDirection(Vector3.forward);
            Vector3 newDirection = Vector3.Reflect(currentDirection, contactPoint.normal);
            transform.rotation = Quaternion.FromToRotation(Vector3.forward, newDirection);
        }
    }
}