using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oscar
public class WaveSystem : MonoBehaviour
{

    public float spawnTime;  
    public GameObject[] enemy;
    public  Transform[] gates ;
    public Transform[] inicialPosition;
    public CollisionSystem col;
   
    void Start()
    {      
            StartCoroutine(Invocation()); 
    }

    private void Awake()
    {


        col = GetComponent<CollisionSystem>();
    }

    IEnumerator Invocation()
    {
        int counter = 0;
        GameObject actualObject;
        for (int i = 0; i <= Globals.waves[Globals.level].Count-1; i++)

        {
            for (int j = 0; j <= Globals.waves[Globals.level][i][2]-1; j++)
            {

                actualObject=Instantiate(enemy[Globals.waves[Globals.level][i][1]], gates[counter].position, Quaternion.identity);
                col.enemies.Add(actualObject);
                actualObject.GetComponent<Enemy>().inicialPosition = inicialPosition[counter];
               


                counter++;
                if (counter > 3) counter = 0;
                
                yield return new WaitForSeconds(spawnTime);
            }
            if (col.enemies.Count==0) Debug.Log("Lista vacía");
            yield return new WaitForSeconds(Globals.waves[Globals.level][i][0]);
            
            Debug.Log("espera");
        }
    }

    private void Update()
    {
        
    }

}
