using System;
using UnityEngine;
using Zenject;

public class Character : IControl,IUpdateble,ILateUpdate
{
    private readonly CharacterMovement _movement;
    private readonly MoneyStorage _moneyStorage;
    private readonly CharacterHealth _health;

    private readonly int _recoilDistance;

    private bool _isGrounded;

    public event Action onDeath;

    public bool IsJump => _movement.IsJump;
    public int Score => _moneyStorage.Value;
    public int Health => _health.CurentHealth;
    public int MaxHealth => _health.MaxHealth;
    public bool IsDeath => Health == _health.MinHealth;
    public Vector2 Direction => _movement.GetDirection();
    
    public float PositionX { get; private set; }
    public int Damage { get; private set; }

    [Inject]
    public Character(CharacterMovement movement,CharacterConfig characterConfig,MoneyLoader moneyLoader)
    {
        _movement = movement;
        _moneyStorage = moneyLoader.Load();
        _health = new CharacterHealth(characterConfig.Health, characterConfig.Health);
        _recoilDistance = characterConfig.RecoilDistance;
        Damage = characterConfig.Damage;

        movement.BindGroundedCheck(() => _isGrounded);
    }

    public void Reset() 
    {
        _moneyStorage.Reset();
        _health.Heal();
    }

    public void SetPositionX(float position)
    => PositionX = position;

    public void Death()
    => _health.Death();

    public void TakeDamage(int damage,TypeMove recoilMove)
    { 
        _health.TakeDamage(damage);
        PositionX += (int)recoilMove * _recoilDistance;
    }

    public void AddMoney(int value)
    => _moneyStorage.AddValue(value);

    public void UpdateGroundState(bool isGrounded)
    => _isGrounded = isGrounded;

    public void Move(float direction)
    { 
        _movement.Move(direction);
        PositionX += _movement.GetDirection().x;
    }

    public void Jump()
    => _movement.Jump();

    public void Update(float delta)
    { 
        _movement.Update(delta);
    }

    public void LateUpdate() 
    => _movement.LateUpdate();

    public void Enable()
    {
        _movement.Enable();
        _health.onDeath += OnDeath;
    }

    public void Disable()
    {
        _movement.Disable();
        _health.onDeath -= OnDeath;
    }

    private void OnDeath()
    => onDeath.Invoke();
}
