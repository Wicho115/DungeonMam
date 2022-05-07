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

    public Nodes Parent; //Almacenará el nodo previo para poder encontrar el camino más corto

    public int gCost; //Distancia para moverse al siguiente "recuadro"
    public int hCost; //Distancia de la meta desde este nodo

    public int FCost { get { return gCost + hCost; } } //Función para añadir G cost y Hcost, ya que no vamos a necesitar F cost no voy a hacer una función xd

    public Nodes(bool a_IsWall,Vector3 a_Pos, int a_gridX, int a_gridY)
    {
        IsWall = a_IsWall; //Le dice al programa si esta siendo obstruido
        Position = a_Pos;  //World Position del Nodo
        gridX = a_gridX;   //Posición X del Node Array
        gridY = a_gridY;   //Posición Y del Node Array
    }

}
