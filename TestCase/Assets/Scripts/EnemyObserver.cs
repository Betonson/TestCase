using UnityEngine;

public class EnemyObserver : MonoBehaviour
{

	private Transform _player;
	[SerializeField] private float _viewRadius;
	[Range(0, 360)]
	[SerializeField] private float _viewAngle;


	void Start()
    {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
		Vector3 direction = _player.position - transform.position;
		Debug.DrawLine(transform.position, _player.position, Color.green, 0, false);
		Ray ray = new Ray(transform.position, direction);
		if (Physics.Raycast(ray, out RaycastHit raycastHit, _viewRadius))
		{
			Debug.Log("Ray hit: " + raycastHit.collider.tag);
			if (raycastHit.collider.CompareTag("Player") && Vector3.Angle(direction, transform.forward) <= (_viewAngle / 2))
			{
				Debug.DrawLine(transform.position, raycastHit.collider.transform.position, Color.red, 0, false);
				Debug.Log("Player is spotted");
			}
		}
	}
}
