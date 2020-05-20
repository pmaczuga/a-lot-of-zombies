using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonsterBehaviour
{
    public Transform raycastStart;
    public float distanceToAttack = 0.9f;
    public float attackRange = 1f;

    private Transform player;
    private int attackHash;
    private int hitHash;
    private WaveScript waveScript;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        waveScript = GameObject.Find("WaveManager").GetComponent<WaveScript>();

        attackHash = Animator.StringToHash("Base Layer.Attack");
        hitHash = Animator.StringToHash("Base Layer.Hit");
    }

    // Update is called once per frame
    override protected void Update()
    {
        if (isDead)
            return;

        agent.destination = player.position;
        agent.isStopped = !CanMove();
        animator.SetFloat("Speed", agent.velocity.magnitude);

        RaycastHit hit;
        if (Physics.Raycast(raycastStart.position, transform.forward, out hit, distanceToAttack) && hit.transform.gameObject.tag == "Player")
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
        if (Physics.Raycast(raycastStart.position, transform.forward, out hit, attackRange))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                CharachterBehaviour cb = hit.collider.gameObject.GetComponent<CharachterBehaviour>();
                cb.ApplyDamage(damage);
            }
        }
    }

    private bool CanMove()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == attackHash)
            return false;
        else if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == hitHash)
            return false;

        return true;
    }

   override public void Die()
    {
        base.Die();
        agent.isStopped = true;
        waveScript.NotifyEnemyKilled();
    }
}
