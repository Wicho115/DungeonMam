using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public Transform inicialPosition;

    protected GameObject target;
    protected NavMeshAgent agent;
    
    protected virtual void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player");
       agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        agent.destination = target.transform.position;
    }
}
