using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private GameObject _wayPoints;
    public bool _canSeePlayer = false;

    int m_CurrentWaypointIndex = 0;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _wayPoints = GameObject.Find("Waypoints_EnemyOne");
        _waypoints = _wayPoints.GetComponentsInChildren<Transform>();
        _navMeshAgent.SetDestination(_waypoints[0].position);
    }

    void Update()
    {
        if (_canSeePlayer)
        {
            _navMeshAgent.SetDestination(_player.transform.position);
        }
        else if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % _waypoints.Length;
            _navMeshAgent.SetDestination(_waypoints[m_CurrentWaypointIndex].position);
        }
    }
}