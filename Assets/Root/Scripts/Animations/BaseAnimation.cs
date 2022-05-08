using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAnimation : MonoBehaviour
{
    [SerializeField]
    private List<AnimFrame> _frames = new List<AnimFrame>();

    public List<AnimFrame> frames => _frames;

    public Coroutine animCoroutine { get; protected set; } = null;

    public void DoAnimation()
    {
        if (frames.Count == 0)
        {
            Debug.LogError("There are no frames on the list");
            return;
        }
        if (animCoroutine is null) animCoroutine = StartCoroutine(BaseAnimationCoroutine());
    }

    private IEnumerator BaseAnimationCoroutine()
    {
        
        yield return StartCoroutine(AnimationCoroutine());
        animCoroutine = null;
        DoAnimation();
    }

    protected virtual IEnumerator AnimationCoroutine()
    {
        for (int i = 0; i < frames.Count; i++)
        {
            var frame = frames[i];
            frame.ActivateFrame();
            yield return new WaitForSeconds(frame.timeFrame);
            frame.DeactivateFrame();
        }
    }
}
