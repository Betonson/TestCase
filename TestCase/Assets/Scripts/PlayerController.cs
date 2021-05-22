using UnityEngine;
using EasyJoystick;

namespace TestCase
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Vector3 _moveInput;
        [SerializeField] private Vector3 _moveVelocity;
        [SerializeField] private Rigidbody _playerRigidbody;
        [SerializeField] private float _playerSpeed = 10.0f;
        [SerializeField] private Joystick joystick;
        [SerializeField] private float _speed;
        //private Vector3 _bulletDirection = this.transform.position - _bulletSpawnPoint.position;

        void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            float vectorX = joystick.Horizontal();
            float vectorZ = joystick.Vertical();

            transform.position += new Vector3(vectorZ, 0.0f, -vectorX) * _speed * Time.deltaTime;

            //_moveInput = new Vector3(Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal") * -1.0f);
            //_moveVelocity = _moveInput * _playerSpeed;

            //_playerRigidbody.velocity = _moveVelocity;

        }

    }
}
