using UnityEngine;
public class EnemyAnimator : BaseGameAnimator, IEnemyAnimator
{
    private readonly EnemyAnimationConfig _animationConfig;

    public EnemyAnimator(EnemyAnimationConfig enemyAnimationConfig,Animator entityAnimator)
    {
        _animationConfig = enemyAnimationConfig;
        BindAnimator(entityAnimator);
    }

    public void Idel() 
    {
        if (IsAnimationPlaying(_animationConfig.IdelAnimationHash))
            return;

        TryEnterAnimation(_animationConfig.IdelAnimationHash);
    }

    public void Run()
    {
        if (IsAnimationPlaying(_animationConfig.RunAnimationHash))
            return;

        TryEnterAnimation(_animationConfig.RunAnimationHash);
    }
}
