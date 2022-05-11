using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oscar

public class CollisionSystem : MonoBehaviour
{
    public static CollisionSystem Instance;

    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> bullets = new List<GameObject>();
    public List<GameObject> enemiesBullets = new List<GameObject>();

    private List<GameObject> bulletsToDestroy = new List<GameObject>();
    private List<Enemy> enemiesToDestroy = new List<Enemy>();

    public GameObject player;
    PlayerController playerController;

    private void Awake()
    {
        if(Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        
        lock (enemies)
        {

            for (int i = 0; i < enemies.Count; i++)
            {
                float col;

                col = Distance(player.transform, enemies[i].transform);

                if (col <= 1.5 && !playerController.damaged)
                {
                    Debug.Log(playerController.damaged);
                    StartCoroutine(playerController.Damaged());

                }

            }
        }
    }

    private void EnemyBulletCollition()
    {
        for (int i = 0; i < enemiesBullets.Count ; i++)
        {
            float col;
            col = Distance(player.transform, enemiesBullets[i].transform);
            //Debug.Log(col + "  " +i);
            if (col <= 1 && !playerController.damaged)
            {

                StartCoroutine(playerController.Damaged());
            }
        }
    }

    private void BulletCollition()
    {
        
        for (int i = 0; i < enemies.Count; i++)
        {
            for (int j = 0; j < bullets.Count; j++)
            {
                float col;
                col = Distance(bullets[j].transform, enemies[i].transform);

                if (col <= 0.75)
                {

                    enemiesToDestroy.Add(enemies[i]);

                    bulletsToDestroy.Add(bullets[j]);
                }
            }
        }

        DestroyEnemies();
        DestroyBullets();
    }

    void DestroyEnemies()
    {
        foreach (var enemy in enemiesToDestroy)
        {
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }

        enemiesToDestroy.Clear();
    }

    void DestroyBullets()
    {
        foreach (var bullet in bulletsToDestroy)
        {
            bullets.Remove(bullet);
            Destroy(bullet.gameObject);
        }

        bulletsToDestroy.Clear();
    }


    public float Distance(Transform A,Transform B)
    {
        float distance;

        distance = Mathf.Sqrt( Mathf.Pow(A.position.x-B.position.x,2) + Mathf.Pow(A.position.y - B.position.y, 2) + Mathf.Pow(A.position.z - B.position.z, 2));
        
        return distance;
    }
}
