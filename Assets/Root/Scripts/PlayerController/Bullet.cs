using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
  
    private Vector3 dir;
    public float counter;
    CollisionSystem col;

    // Start is called before the first frame update
    void Start()
    {
        col = GameObject.Find("WaveSystem").GetComponent<CollisionSystem>();
        dir = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        
            var actualRotation = (MyQuaternion)transform.rotation;
            var moveDir =   actualRotation.Rotate((MyVector3)dir);
            transform.position += (Vector3)(speed * Time.deltaTime* moveDir);
            counter -= Time.deltaTime;

        if (counter <= 0)
        {
            Destroy(gameObject);
            col.bullets.Remove(gameObject);
        }

    }
}
