using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void CargarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
        
    }

    public void Salir()
    {
        Application.Quit();
    }
}
