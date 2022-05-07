using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridz : MonoBehaviour
{
    public Transform StartPosition;
    public LayerMask WallsMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float Distance;

    Nodes[,] grid;
    public List<Nodes> FinalPath;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Nodes[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
        for (int y =0; y<gridSizeX;y++)
        {
            for(int x=0;x<gridSizeX;x++)
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool Wall = true;

                if(Physics.CheckSphere(worldPoint,nodeRadius,WallsMask))
                {
                    Wall = false;
                }

                grid[x, y] = new Nodes(Wall, worldPoint, x, y);
            }
        }
    }

    public Nodes NodeFromWorldPosition(Vector3 a_WorldPosition)
    {
        float xpoint = ((a_WorldPosition.x = gridWorldSize.x / 2) / gridWorldSize.x);
        float ypoint = ((a_WorldPosition.y = gridWorldSize.y / 2) / gridWorldSize.x);

        xpoint = Mathf.Clamp01(xpoint);
        ypoint = Mathf.Clamp01(ypoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xpoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * ypoint);

        return grid[x, y];
    }
    public List<Nodes> GetNeighboringNodes(Nodes a_Node)
    {
        List<Nodes> NeighboringNodes = new List<Nodes>();
        int xCheck;
        int yCheck;

        //Right Side
        xCheck = a_Node.gridX + 1;
        yCheck = a_Node.gridX ;
        if(xCheck>=0 && xCheck<gridSizeX)
        {
            if(yCheck>=0 && yCheck<gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Left Side
        xCheck = a_Node.gridX -1;
        yCheck = a_Node.gridX;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Top Side
        xCheck = a_Node.gridX;
        yCheck = a_Node.gridX +1;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Bottom Side
        xCheck = a_Node.gridX;
        yCheck = a_Node.gridX - 1;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        return NeighboringNodes;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if(grid!=null)
        {
            foreach (Nodes node in grid)
            {
                if (node.IsWall)
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }
                if(FinalPath!=null)
                {
                    Gizmos.color = Color.red;
                }

                Gizmos.DrawCube(node.Position, Vector3.one * (nodeDiameter - Distance));
            }
        }
    }

}
