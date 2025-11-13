using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

public class CharacterMovement : IControl,ILateUpdate,IUpdateble
{
    private readonly float _forceJump;
    private readonly float _speedMove;

    private bool _canJump = true;
    private bool _isInitDirectionFrame = false;

    private Vector2 DirectionFrame;
    private float _directionX;
    private float _directionY;
    private bool _isEable;

    private Func<bool> isGrounded;

    public bool IsJump { get; private set; }

    [Inject]
    public CharacterMovement(CharacterMovementConfig config) 
    {
        _speedMove = config.SpeedMove;
        _forceJump = config.ForceJump;
    }

    public void BindGroundedCheck(Func<bool> groundedCheck) 
    => isGrounded = groundedCheck;

    public async UniTaskVoid Jump()
    {
        if (_isEable == false)
            return;

        if (_canJump == false || CheckConditions() == false)
            return;

        _directionY = _forceJump;
        _canJump = false;

        while (true) 
        {
            if (CheckConditions() == false)
            {
                IsJump = true;
                return;
            }

            await UniTask.Yield();
        }
    }

    public void Move(float diraction)
    {
        if (_isEable == false)
            return;

        _directionX = diraction * _speedMove * Time.deltaTime;
    }

    public void LateUpdate()
    => _isInitDirectionFrame = false;

    public Vector2 GetDirection()
    {
        if (_isInitDirectionFrame)
            return DirectionFrame;

        DirectionFrame = Vector2.right * _directionX + Vector2.up * _directionY;
        _isInitDirectionFrame = true;
        _directionY = 0;
        _directionX = 0;

        return DirectionFrame;
    }

    public void Update(float delta) 
    {
        if (IsJump) 
        {
            if (CheckConditions()) 
            {
                IsJump = false;
                _canJump = true;   
            }
        }
    }

    public void Enable()
    => _isEable = true;

    public void Disable()
    => _isEable = false;

    private bool CheckConditions() 
    {
        Delegate[] actions = isGrounded?.GetInvocationList();
        Func<bool> action;

        for (int i = 0; i < actions.Length; i++) 
        {
            action = actions[i] as Func<bool>;
            bool result = action.Invoke();
            
            if(result == false)
                return false;
        }

        return true;
    }
}