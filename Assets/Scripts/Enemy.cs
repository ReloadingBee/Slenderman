using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float viewDistance;
    public float wanderDistance = 5f;
    public float speed;

    Rigidbody rb;
    NavMeshAgent agent;

    public Animator animator;

    private void Start()
    {
         rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator.Play("Idle");
    }

    private void Update()
    {
        if (target == null) return;

        agent.speed = speed;

        if(agent.velocity != Vector3.zero)
        {
            animator.Play("Run");
        }
        else
        {
            animator.Play("Idle");
        }

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
                agent.destination += Random.insideUnitSphere * wanderDistance;
            }
        }
    }
}
