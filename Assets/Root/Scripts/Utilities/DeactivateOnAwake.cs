using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1)]
public class DeactivateOnAwake : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }
}
