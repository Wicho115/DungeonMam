using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyudaPaneles : MonoBehaviour
{
    public GameObject DeadPanel;
    public GameObject WinPanel;

    private void Start()
    {
        GameManager.DeadGame += OnDead;
        GameManager.WinGame += OnWin;
    }

    private void OnDead()
    {
        DeadPanel.SetActive(true);
    }

    private void OnWin()
    {
        WinPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.DeadGame -= OnDead;
        GameManager.WinGame -= OnWin;
    }
}
