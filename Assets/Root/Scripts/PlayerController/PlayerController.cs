using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontal;
    float vertical;
    public float speed;
    public Transform shootPoint;
    public CollisionSystem col;
    public GameObject bullet;
    public float delay;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Movement();
        PlayerRotation();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject actualObject;
        actualObject = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        col.bullets.Add(actualObject);
        actualObject.GetComponent<Bullet>().isActivated = true;
    
        
    }

    void Movement()
    {
        transform.position += new Vector3(horizontal * speed*Time.deltaTime,0,vertical*speed*Time.deltaTime);
    }

    void PlayerRotation()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = mouseOnScreen - positionOnScreen;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;

        transform.rotation =(Quaternion) MyQuaternion.AngleRotation(-angle, AngleAxis.y);
            
    }
}
