using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterBehaviour : CharachterBehaviour
{
    public int damage = 10;

    protected NavMeshAgent agent;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

}
