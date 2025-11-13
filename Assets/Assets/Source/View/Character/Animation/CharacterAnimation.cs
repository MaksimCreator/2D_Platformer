using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
public class CharacterAnimation : BaseGameAnimator,ICharacterAnimation
{
    private readonly CharacterAnimationConfig _animationConfig;
    private readonly Sprite _jumpSprite;
    
    private SpriteRenderer _characterSpriteRenderer;
    private Sprite _defoltSprite;

    private Tween _animation;

    private bool _canSwithAnimation = true;

    private Tween _disappear => ManualFadeTo(0, _animationConfig.DurationDisappearSecond);
    private Tween _appears => ManualFadeTo(1, _animationConfig.DurationAppearsSecond);

    public CharacterAnimation(Sprite jumpSprite,CharacterAnimationConfig animationConfig)
    {
        _animationConfig = animationConfig;
        _jumpSprite = jumpSprite;
    }

    public CharacterAnimation BindCahracterData(SpriteRenderer spriteRenderer, Animator animator) 
    {
        _characterSpriteRenderer = spriteRenderer;
        _defoltSprite = spriteRenderer.sprite;
        BindAnimator(animator);
        return this;
    }

    public void Idel()
    {
        if (IsAnimationPlaying(_animationConfig.IdelCharacterAnimation) || _canSwithAnimation == false)
            return;

        __entityAnimator.enabled = true;
        _characterSpriteRenderer.sprite = _defoltSprite;

        TryEnterAnimation(_animationConfig.IdelCharacterAnimation);
    }

    public void Run()
    {
        if (IsAnimationPlaying(_animationConfig.RunCharacterAnimation) || _canSwithAnimation == false)
            return;

        __entityAnimator.enabled = true;
        _characterSpriteRenderer.sprite = _defoltSprite;

        TryEnterAnimation(_animationConfig.RunCharacterAnimation);
    }

    public void Jump()
    {
        if (_canSwithAnimation == false)
            return;

        __entityAnimator.enabled = false;
        _characterSpriteRenderer.sprite = _jumpSprite;
    }

    public async UniTask TakeDamage()
    {
        if (_canSwithAnimation == false)
            return;

        __entityAnimator.enabled = false;
        _canSwithAnimation = false;

        for (int i = 0; i < _animationConfig.CountBlinks; i++) 
        {
            await SetAndPlayAnimation(_disappear);
            await SetAndPlayAnimation(_appears);
        }

        __entityAnimator.enabled = true;
        _canSwithAnimation = true;
    }

    private async UniTask SetAndPlayAnimation(Tween tween)
    {
        _animation = tween;
        _animation.Play();
        await _animation.AsyncWaitForCompletion();
    }

    private Tween ManualFadeTo(float targetAlphaValue, float duration)
    {
        Color currentColor = _characterSpriteRenderer.color;
        Color targetColor = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlphaValue);

        return DOTween.To(() => _characterSpriteRenderer.color, color => _characterSpriteRenderer.color = color, targetColor, duration)
                          .SetEase(Ease.Linear)
                          .Pause();
    }
}