using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFrame : MonoBehaviour
{
    [SerializeField] private float _timeFrame;
    public float timeFrame => _timeFrame;

    public void ActivateFrame()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateFrame()
    {
        gameObject.SetActive(false);
    }
}
