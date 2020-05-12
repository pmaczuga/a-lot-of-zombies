using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharachterBehaviour : MonoBehaviour
{
    public int health;

    protected bool isDead = false;
    protected Animator animator;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
    }

    virtual public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    virtual public void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        DisableColliders();
    }

    virtual public void DisableColliders()
    {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = false;
        }
    }
}
