using UnityEngine;
using UnityEngine.AI;

public class SimpleNavMeshFollow : MonoBehaviour
{

    public Transform m_target;
    NavMeshAgent m_agent;

    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        m_agent.SetDestination(m_target.position);
    }
}
