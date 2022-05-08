using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool isActivated;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            var actualRotation = (MyQuaternion)transform.rotation;
            var moveDir =   actualRotation.Rotate((MyVector3)dir);
            transform.position += (Vector3)(speed * Time.deltaTime* moveDir);
           
        }

    }
}
