using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterBehaviour : CharachterBehaviour
{
    public int damage = 10;
    public int points = 10;

    protected NavMeshAgent agent;
    protected UIScript uiScript;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        uiScript = GameObject.Find("UIText").GetComponent<UIScript>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    override public void Die()
    {
        base.Die();
        uiScript.AddScore(points);
    }
}
