 
using UnityEngine;
using TMPro;

public class BalasShidas : MonoBehaviour
{
    public float speed; //Declaramos la velocidad de la bala

    private Transform player; //Declaramos para obtener el Transform del jugador para que la bala lo pueda seguir
    private Vector3 target;   //Es lo mismo que el anterior pero ahora Vector3 xd

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Obtenemos el transform del jugador

        target = new Vector3(player.position.x, player.position.y, player.position.z); //Con esto obtenemos la posición x,y,z del target que sería el jugador
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);  //Declaramos que la bala se mueva hacía el jugador

        if(transform.position.x==target.x && transform.position.y==target.y && transform) //Si se aleja mucho del jugador hacemos que se destruya la bala
        {
            DestroyProjectile();
        }


    }

    private void OnCollisionEnter(Collision collision) //Checa si colisiono con el jugador. Si lo hizo entonces se destruirá la bola
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    void DestroyProjectile()  //Sirve para destruir la bola en caso de no haber golpeado el jugador
    {
        Destroy(gameObject);
    }
}
