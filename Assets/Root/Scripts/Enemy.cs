using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform inicialPosition;
    public CollisionSystem col;
    public GameObject target;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
       agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void Update()
    {
        
       

        agent.destination = target.transform.position;
    }
}
