using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimationController : MonoBehaviour
{
    public BaseAnimation actualAnimation;

    private void Start()
    {
        actualAnimation.DoAnimation();
    }
}
