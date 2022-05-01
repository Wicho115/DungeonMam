using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNav : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform; //Declaramos al objeto al que va a seguir
    private NavMeshAgent navMeshAgent; //Utilizamos el NavMesh de Unity

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //Obtenemeos el NavMesh del Objeto
    }

    private void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;   //Hacemos que el objeto siga al objeto deseado
    }
}
