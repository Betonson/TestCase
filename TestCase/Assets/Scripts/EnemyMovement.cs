using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private GameObject _wayPointsGroup;
    public bool _canSeePlayer = false;

    int m_CurrentWaypointIndex = 0;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _wayPointsGroup = GameObject.Find("Waypoints_EnemyOne");
        _waypoints = new Transform[_wayPointsGroup.transform.childCount];
        for (int i = 0; i< _wayPointsGroup.transform.childCount; i++)
        {
            _waypoints[i] = _wayPointsGroup.transform.GetChild(i);
        }
        //_waypoints = _wayPointsGroup.GetComponentsInChildren<Transform>();
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