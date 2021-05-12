using UnityEngine;

namespace TestCase
{
    public class FieldOfView_SimpleRaycast : MonoBehaviour
    {
        [SerializeField] private float _detectionDistance;
        [SerializeField] private float _detectionAngle;
        [SerializeField]  private Light _enemySpotLight;
        private GameObject _player;
        
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        
        void Update()
        {
            Vector3 direction = _player.transform.position - transform.position;
            Debug.DrawLine(transform.position, _player.transform.position, Color.green, 0, false);
            Ray ray = new Ray(transform.position, direction);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, _detectionDistance))
            {
                Debug.Log("Ray hit: " + raycastHit.collider.tag);
                if (raycastHit.collider.CompareTag("Player") && Vector3.Angle(direction, transform.forward) <= (_detectionAngle/2))
                {
                    Debug.DrawLine(transform.position, raycastHit.collider.transform.position, Color.red, 0, false);
                    Debug.Log("Player is spotted");
                    _enemySpotLight.color = Color.red;
                    //GetComponent<EnemySpotLight>();
                }
                else
                {
                    _enemySpotLight.color = Color.white;
                }
            }
            else
            {
                _enemySpotLight.color = Color.white;
            }

        }
        private Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180.0f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }
    }
}