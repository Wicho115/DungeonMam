using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Gridz grid;
    public Transform StartPosition;
    public Transform TargetPosition;

    private void Awake()
    {
        grid = GetComponent<Gridz>();
    }

    private void Update()
    {
        FindPath(StartPosition.position, TargetPosition.position);
    }

    void FindPath(Vector3 a_StartPos,Vector3 a_TargetPos)
    {
        Nodes StartNode = grid.NodeFromWorldPosition(a_StartPos);
        Nodes TargetNode = grid.NodeFromWorldPosition(a_TargetPos);

        List<Nodes> OpenList = new List<Nodes>();
        HashSet<Nodes> ClosedList = new HashSet<Nodes>();

        OpenList.Add(StartNode);

        while(OpenList.Count>0)
        {
            Nodes CurrentNode = OpenList[0];
                for(int i=1; i<OpenList.Count;i++)
            {
                if(OpenList[i].FCost<CurrentNode.FCost || OpenList[i].FCost==CurrentNode.FCost && OpenList[i].hCost<CurrentNode.hCost)
                {
                    CurrentNode = OpenList[i];
                }
            }
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if(CurrentNode==TargetNode)
            {
                GetFinalPath(StartNode, TargetNode);
            }

            foreach(Nodes NeighbourNode in grid.GetNeighboringNodes(CurrentNode))
            {
                if(!NeighbourNode.IsWall || ClosedList.Contains(NeighbourNode))
                {
                    continue;
                }
                int MoveCost = CurrentNode.gCost + GetManhattenDistance(CurrentNode, NeighbourNode);

                if (MoveCost<NeighbourNode.gCost|| !OpenList.Contains(NeighbourNode))
                {
                    NeighbourNode.gCost = MoveCost;
                    NeighbourNode.hCost = GetManhattenDistance(NeighbourNode, TargetNode);
                    NeighbourNode.Parent = CurrentNode;

                    if(!OpenList.Contains(NeighbourNode)||MoveCost<NeighbourNode.FCost)
                    {
                        OpenList.Add(NeighbourNode);
                    }
                }
            }
        }
    }

    void GetFinalPath(Nodes a_StartingNode, Nodes a_EndNode)
    {
        List<Nodes> FinalPath = new List<Nodes>();
        Nodes CurrentNode = a_EndNode;

        while(CurrentNode !=a_StartingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;
        }

        FinalPath.Reverse();

        grid.FinalPath = FinalPath;
    }

    int GetManhattenDistance(Nodes a_nodeA, Nodes a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.gridX - a_nodeB.gridX);
        int iy= Mathf.Abs(a_nodeA.gridY - a_nodeB.gridY);

        return ix + iy;
    }
}
