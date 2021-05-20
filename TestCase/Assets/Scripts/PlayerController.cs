using UnityEngine;

namespace TestCase
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Vector3 _moveInput;
        [SerializeField] private Vector3 _moveVelocity;
        [SerializeField] private Rigidbody _playerRigidbody;
        [SerializeField] private float _playerSpeed = 10.0f;
        //private Vector3 _bulletDirection = this.transform.position - _bulletSpawnPoint.position;

        void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            //float vectorX = Input.GetAxis("Horizontal");
            //float vectorZ = Input.GetAxis("Vertical");

            //transform.position -= transform.forward * vectorX * _speed * Time.deltaTime;
            //transform.position += transform.right * vectorZ * _speed * Time.deltaTime;

            _moveInput = new Vector3(Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal") * -1.0f);
            _moveVelocity = _moveInput * _playerSpeed;

            _playerRigidbody.velocity = _moveVelocity;

        }

    }
}
