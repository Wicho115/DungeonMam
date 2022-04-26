using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oscar
public class WaveSystem : MonoBehaviour
{

  
    public GameObject[] enemy;
    public  Transform[] gates ;
    public Transform[] inicialPosition;
  

    void Update()
    {
        
            StartCoroutine(Invocation());
            
            
          
    }


    IEnumerator Invocation()
    {
        int counter = 0;
        GameObject actualObject;
        for (int i = 0; i <= Globals.waves[Globals.level].Count; i++)

        {
            for (int j = 0; j <= Globals.waves[Globals.level][i][2]; j++)
            {

               Instantiate(enemy[Globals.waves[Globals.level][i][1]], gates[counter].position, Quaternion.identity);

                //actualObject.GetComponent<Enemy>().inicialPosition = inicialPosition[counter];
                //Globals.enemies.Add(actualObject);


                counter++;
                if (counter > 3) counter = 0;
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(Globals.waves[Globals.level][i][0]);
            Debug.Log("espera");
        }
    }

}
