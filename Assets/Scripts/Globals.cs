using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oscar
public class Globals : MonoBehaviour
{
   public static int level = 1;


    public static List<GameObject> enemies = new List<GameObject>();
    public static List<List<int[]>> waves = new List<List<int[]>>()
    {
        new List<int[]>(){new int[] {50,0,5},new int[] {50,0,6},new int[] {50,0,8},new int[] {50,0,10},new int[] {50,0,10},new int[] {1,0,12} },
        new List<int[]>(){new int[] {50,0,5},new int[] {50,0,6},new int[] {50,0,8},new int[] {50,0,10},new int[] {50,0,10},new int[] {1,0,12} },
        new List<int[]>(){new int[] {50,0,5},new int[] {50,0,6},new int[] {50,0,8},new int[] {50,0,10},new int[] {50,0,10},new int[] {1,0,12} },
        new List<int[]>(){new int[] {50,0,5},new int[] {50,0,6},new int[] {50,0,8},new int[] {50,0,10},new int[] {50,0,10},new int[] {1,0,12} },
        new List<int[]>(){new int[] {50,0,5},new int[] {50,0,6},new int[] {50,0,8},new int[] {50,0,10},new int[] {50,0,10},new int[] {1,0,12} },
        new List<int[]>(){new int[] {50,0,5},new int[] {50,0,6},new int[] {50,0,8},new int[] {50,0,10},new int[] {50,0,10},new int[] {1,0,12} },
        new List<int[]>(){new int[] {50,0,5},new int[] {50,0,6},new int[] {50,0,8},new int[] {50,0,10},new int[] {50,0,10},new int[] {1,0,12} },
        new List<int[]>(){new int[] {50,0,5},new int[] {50,0,6},new int[] {50,0,8},new int[] {50,0,10},new int[] {50,0,10},new int[] {1,0,12} },

    };


}
