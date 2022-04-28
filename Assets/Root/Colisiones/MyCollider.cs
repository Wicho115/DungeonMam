using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyCollider : MonoBehaviour
{
    private bool m_isEnable;
    public bool isEnable => m_isEnable;


    public abstract void CheckCollision();

    private void OnEnable()
    {
        m_isEnable = true;
    }

    private void OnDisable()
    {
        m_isEnable = false;
    }
}

public struct MyCollision
{
    public GameObject other;

    public MyCollision(GameObject obj)
    {
        other = obj;
    }
}