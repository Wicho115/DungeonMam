using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontal;
    float vertical;
    public float speed;
    public Transform shootPoint;
    public CollisionSystem col;
    public GameObject bullet;
    public bool damaged;
    public float life;

    [Header("Shoot parameters"), SerializeField]
    private float _timeBetweenShoots = 0.5f;
    private bool _canShoot = true;

    [SerializeField]
    private Image[] heartImages;

    void Start()
    {
        col = CollisionSystem.Instance;
        damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Movement();
        PlayerRotation();

        if (Input.GetMouseButtonDown(0) && _canShoot)
        {
            StartCoroutine(Shoot());
        }
        
    }

    private bool isDead = false;
    public IEnumerator Damaged()
    {
        if (isDead) yield break;
        damaged = true;
        life--;
        heartImages[(int)life].gameObject.SetActive(false);
        SoundManager.Instance.PlayAudio(SoundManager.Sounds.Hit);
        if (life <= 0)
        {
            StartCoroutine(Dead());
            yield break;
        }
        Debug.Log("life:" + life);
        yield return new WaitForSeconds(2f);
        damaged = false;

    }

    public IEnumerator Dead() 
    {
        isDead = true;
        GameManager.Instance.EndGameDead();
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.PlayAudio (SoundManager.Sounds.Dead);
    }

    IEnumerator Shoot()
    {
        _canShoot = false;
        GameObject actualObject;
        actualObject = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        col.bullets.Add(actualObject);
        SoundManager.Instance.PlayAudio(SoundManager.Sounds.Shoot);
        yield return new WaitForSeconds(_timeBetweenShoots);
        _canShoot = true;
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
