using System;
using UnityEditor.Animations;
using UnityEngine;

public abstract class BaseGameAnimator
{
    protected Animator __entityAnimator;

    protected void BindAnimator(Animator animator)
    => __entityAnimator = animator;

    public float GetLengchClip(int animationHash)
    {
        AnimatorController animatorController = __entityAnimator.runtimeAnimatorController as AnimatorController;

        if (animatorController != null)
        {
            foreach (var layer in animatorController.layers)
            {
                foreach (var state in layer.stateMachine.states)
                {
                    if (state.state.nameHash == animationHash)
                    {
                        AnimationClip clip = state.state.motion as AnimationClip;
                        return clip.length;
                    }
                }
            }
        }

        throw new InvalidOperationException();
    }

    protected void TryEnterAnimation(int hashAnimation)
    {
        if (__entityAnimator == null)
            return;

        __entityAnimator.CrossFade(hashAnimation,0f);
    }

    protected bool IsAnimationPlaying(int animationHash)
    {
        AnimatorStateInfo stateInfo = __entityAnimator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.shortNameHash == animationHash && stateInfo.normalizedTime < 1.0f;
    }
}
