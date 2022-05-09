using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceEnemy : MonoBehaviour
{
    public NavMeshAgent agent;  //Obtenemos El navMesh
    public Transform player;    //Transform para moverse
    public float health=20; //La vida del Enemigo

    public LayerMask whatIsPlayer,whatIsGround;  //Define qué es el jugador/objetivo, y que es lo que puede caminar

    //Attacking
    public float timeBetweenAttacks;     //Tiempo que debe de esperar entre ataques
    bool alreadyAttacked;                //bool para determinar si ya ataco
    public GameObject projectile;        //Declaramos el proyectil que usará

    //States
    public float sightRange, attackRange;   //declaramos el rango de vista y el de ataque
    public bool  playerInAttackRange;       //Declaramos un bool cuándo el objeto este en rango de ataque
    public bool playerInSightRange;         //Declaramos un bool cuándo el objeto este en rango de vista, este es casi inutil, pero ayuda a que funcione el código xd

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        player = GameObject.Find("PlayerObj").transform;  //Obtenemos El transform del jugador.
        agent = GetComponent<NavMeshAgent>();//Obtenemeos el NavMesh del Objeto
    }

    private void Update()
    {
        //Toda esta parte servirá para que el enemigo persiga al jugador. Siempre estará activo un Rango para detectar si el jugador esta cerca para que sea atacado o no.
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer); 
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        //Para que mire al jugador por medio de Quaterniones ;)
        Vector3 directiontoFace = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directiontoFace);

        Chase();
    }

    private void Chase()
    {
        
        agent.destination = player.position;//Hacemos que el objeto siga al objeto deseado
        if (playerInAttackRange) AttackPlayer(); //Empieza a atacar al jugador una vez que lo encuentre.
    }

    private void AttackPlayer()
    {
        //Estas 2 lineas hacen que el enemigo no se mueva mientras dispare
        agent.SetDestination(transform.position);
       

        //Esto sirve para que se inicie la secuencia de ataque
        if(!alreadyAttacked) 
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>(); //Instancia el proyectil y obtiene su Rigidbody

            alreadyAttacked = true; //Ponemos el alreadyattacked como true
            Invoke(nameof(ResetAttack), timeBetweenAttacks); //Llamamos el metodo de Reset attack, lo que hace que se reinicie el ataque después del tiempo que declaramos en TimeBetweenAttacks
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false; //Declaramos false para que pueda volver a atacar
    }

    //Esto se supone que hace que el enemigo muera y se destruya después de tener su vida debajo o igual a 0
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f); 
        
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    
}
