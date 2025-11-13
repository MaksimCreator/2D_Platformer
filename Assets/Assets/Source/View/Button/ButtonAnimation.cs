using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System;
using Zenject;

public class ButtonAnimation : IButtonAnimation
{
    private float _scaleFacror;
    private float _durationIncrease;
    private float _durationDecrease;

    private Transform _buttonTransform;
    private Tween _increase;
    private Tween _decrease;

    private Vector2 _startScale;
    private Vector2 _increaseScale;

    public bool CanAnimation { get; private set; } = true;

    [Inject]
    private void Construct(ButtonAnimationConfig config)
    {
        _scaleFacror = config.ScaleFactor;
        _durationIncrease = config.DurationIncrease;
        _durationDecrease = config.DurationDecrease;
    }

    public async UniTask EnterAnimation(Button button)
    {
        if (CanAnimation == false)
            throw new InvalidOperationException();

        CanAnimation = false;
        _buttonTransform = button.transform;
        _startScale = _buttonTransform.localScale;
        _increaseScale = new Vector2(_startScale.x * _scaleFacror, _startScale.y * _scaleFacror);

        CreatAnimation();

        _increase.Play();
        await _increase.AsyncWaitForCompletion();

        _decrease.Play();
        await _decrease.AsyncWaitForCompletion();

        CanAnimation = true;

        return;
    }

    private void CreatAnimation() 
    {
        _increase = _buttonTransform.DOScale(_increaseScale, _durationIncrease).Pause();
        _decrease = _buttonTransform.DOScale(_startScale,_durationDecrease).Pause();
    }
}