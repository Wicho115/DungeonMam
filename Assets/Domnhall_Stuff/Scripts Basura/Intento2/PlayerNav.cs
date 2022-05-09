using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNav : MonoBehaviour
{
    [SerializeField] private Transform player; //Declaramos al objeto al que va a seguir
    private NavMeshAgent navMeshAgent; //Utilizamos el NavMesh de Unity

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        navMeshAgent = GetComponent<NavMeshAgent>(); //Obtenemeos el NavMesh del Objeto
    }

    private void Update()
    {
        //Para que mire al jugador por medio de Quaterniones ;)
        Vector3 directiontoFace = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directiontoFace);
        navMeshAgent.destination = player.position;   //Hacemos que el objeto siga al objeto deseado
    }
}
