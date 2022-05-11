using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyudaEscenas : MonoBehaviour
{
    public void Retry()
    {
        GameManager.Instance.RetryGame();
    }

    public void Menu()
    {
        GameManager.Instance.Menu();
    }
}
