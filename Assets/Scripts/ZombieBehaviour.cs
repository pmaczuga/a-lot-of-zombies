using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    public Transform player;
    public Transform raycastStart;
    public float distanceToAttack = 0.9f;
    public float attackRange = 1f;
    public int damage = 10;

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
        Debug.Log(agent.isStopped);

        agent.destination = player.position;
        agent.isStopped = !CanMove();
        animator.SetFloat("Speed", agent.velocity.magnitude);

        RaycastHit hit;
        if (Physics.Raycast(raycastStart.position, transform.forward, out hit, distanceToAttack))
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }

        if (agent.velocity == Vector3.zero)
        {
            Vector3 lookPos = player.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
        }
    }

    public void ZombieAttackHitEvent()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastStart.position, transform.forward, out hit, distanceToAttack))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                PlayerController pc = hit.collider.gameObject.GetComponent<PlayerController>();
                pc.DealDamage(damage);
            }
        }
    }

    private bool CanMove()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == attackHash)
        {
            return false;
        }
            
        return true;
    }
}
