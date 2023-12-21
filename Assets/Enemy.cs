using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float viewDistance;
    public float wanderDistance = 5f;

    Rigidbody rb;
    NavMeshAgent agent;

    private void Start()
    {
         rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);

        if(distance < viewDistance)
        {
            // CHASE
            agent.destination = target.position;
        }
        else
        {
            // SEEK
            if(agent.velocity == Vector3.zero)
            {
                agent.destination = Random.insideUnitSphere * wanderDistance;
            }
        }
    }
}
