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
            float time = Time.time;
            float objectiveTime = time + Globals.waves[Globals.level][i][0];
            for (int j = 0; j <= Globals.waves [Globals.level][i][2]-1; j++)
            {

                actualObject = Instantiate(enemy[Globals.waves[Globals.level][i][1]], gates[counter].position, (Quaternion)MyQuaternion.identidad);
                col.enemies.Add(actualObject);

                if (Globals.waves[Globals.level][i][1] == 0)
                {
                    actualObject.GetComponent<Enemy>().inicialPosition = inicialPosition[counter];
                }

                else if (Globals.waves[Globals.level][i][1] == 1)
                {
                    actualObject.GetComponent<Enemy2>().inicialPosition = inicialPosition[counter];
                }


                counter++;
                if (counter > 3) counter = 0;
                
                yield return new WaitForSeconds(spawnTime);
            }

            do {
                time += Time.deltaTime;
               
                yield return null;
            } while (time<objectiveTime&&col.enemies.Count>0);
            

            
        }
    }

    private void Update()
    {
        
    }
}
