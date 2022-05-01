using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes 
{
    //Posisciones X y Y en el Node Array
    public int gridX;
    public int gridY;

    
    public bool IsWall; //Indica si el Nodo esta siendo obstruido
    public Vector3 Position; //World Position del Nodo

    public Nodes Parent; //Almacenar� el nodo previo para poder encontrar el camino m�s corto

    public int gCost; //Distancia para moverse al siguiente "recuadro"
    public int hCost; //Distancia de la meta desde este nodo

    public int FCost { get { return gCost + hCost; } } //Funci�n para a�adir G cost y Hcost, ya que no vamos a necesitar F cost no voy a hacer una funci�n xd

    public Nodes(bool a_IsWall,Vector3 a_Pos, int a_gridX, int a_gridY)
    {
        IsWall = a_IsWall; //Le dice al programa si esta siendo obstruido
        Position = a_Pos;  //World Position del Nodo
        gridX = a_gridX;   //Posici�n X del Node Array
        gridY = a_gridY;   //Posici�n Y del Node Array
    }

}
