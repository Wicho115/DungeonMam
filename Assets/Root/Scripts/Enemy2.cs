using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    public Transform inicialPosition;
    public CollisionSystem col;
    public GameObject target;
    public NavMeshAgent agent;
    public GameObject bullet;
    public Transform shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        col = GameObject.Find("WaveSystem").GetComponent<CollisionSystem>();
        InvokeRepeating("Shooting",3, 3);
    }

    // Update is called once per frame
    public void Update()
    {
        transform.LookAt(target.transform);

        agent.destination = inicialPosition.transform.position;
    }

    void Shooting()
    {
        GameObject actualObject;
        actualObject = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        col.enemiesBullets.Add(actualObject);
    }
}