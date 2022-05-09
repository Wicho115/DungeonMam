using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunEnemy : Enemy
{
    public GameObject bullet;
    public Transform shootPoint;

    private CollisionSystem col;

    protected override void Start()
    {
        base.Start();
        col = CollisionSystem.Instance;
        InvokeRepeating(nameof(Shooting),3, 3);
    }

    protected override void Update()
    {
        transform.LookAt(target.transform);

        agent.destination = inicialPosition.transform.position;
    }

    void Shooting()
    {
        var actualObject = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        col.enemiesBullets.Add(actualObject);
    }
}