using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    public Transform player;
    public float distanceToAttack = 1.8f;

    private Animator animator;
    private NavMeshAgent agent;
    private int attackHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        attackHash = Animator.StringToHash("Base Layer.Attack");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);
        if (agent.remainingDistance < distanceToAttack)
        {
            Vector3 lookPos = player.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            agent.isStopped = true;
            animator.SetBool("Attack", true);
        } 
        else
        {
            animator.SetBool("Attack", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != attackHash)
        {
            agent.isStopped = false;
        }
    }
}
