using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSequenceAnimator : MonoBehaviour
{
    public bool wait;
    float WaitBetween = .15f;
    float WaitDelay = 1f;

    List<Animator> _animators;

    void Start()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(DoAnimation());
    }

    // times bounce effect on each letter of text in start menu
    IEnumerator DoAnimation() {
        while (true) {
            foreach (var animator in _animators) {  
                    animator.SetTrigger("DoAnimation");
                    yield return new WaitForSeconds(WaitBetween);
            }
            if (wait) {
                yield return new WaitForSeconds(WaitDelay);
            }
        }
    }
}
