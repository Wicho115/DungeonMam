using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletoAnimationController : MonoBehaviour
{
    public BaseAnimation actualAnimation;

    private void Start()
    {
        actualAnimation.DoAnimation();
    }
}
