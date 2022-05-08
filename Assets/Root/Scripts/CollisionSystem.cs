using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oscar

public class CollisionSystem : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject player;
    public List<GameObject> bullets = new List<GameObject>();
    public List<GameObject> enemiesBullets = new List<GameObject>();
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCollition();
        EnemyBulletCollition();
        BulletCollition();
       
    }

    private void EnemyCollition()
    {
        for (int i = 0; i <= enemies.Count - 1; i++)
        {
            float col;
           
            col = Distance(player.transform, enemies[i].transform);
           
            if (col <= 1.5 && !playerController.damaged)
            {
                playerController.damaged = true;
               
                Debug.Log("Damaged");

            } 

        }
    }

    private void EnemyBulletCollition()
    {
        for (int i = 0; i <= enemiesBullets.Count - 1; i++)
        {
            float col;
            col = Distance(player.transform, enemiesBullets[i].transform);
            //Debug.Log(col + "  " +i);
            if (col <= 1)
            {
                Debug.Log("Colisi�n con enemigo no:" + i);

            }
        }
    }

    private void BulletCollition()
    {
        for (int i = 0; i <= enemies.Count - 1; i++)
        {
            for (int j = 0; j <= bullets.Count - 1; j++) { 
                float col;
            col = Distance(bullets[j].transform, enemies[i].transform);
            //Debug.Log(col + "  " +i);
            if (col <= 0.75)
            {
                Debug.Log("Colision con bala" + i);
                    Destroy(enemies[i]);
                    enemies.RemoveAt(i);

                    Destroy(bullets[j]);
                    bullets.RemoveAt(j);
                }
        }
        }
    }




    public float Distance(Transform A,Transform B)
    {
        float distance;

        distance = Mathf.Sqrt( Mathf.Pow(A.position.x-B.position.x,2) + Mathf.Pow(A.position.y - B.position.y, 2) + Mathf.Pow(A.position.z - B.position.z, 2));
        
        return distance;
    }
}
