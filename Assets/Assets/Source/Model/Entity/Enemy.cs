using System;

public class Enemy : IControl
{
    private readonly Health _health;

    public event Action onDeath;

    public int DamageCharacter { get; private set; }
    public float DirectionMoveX { get; private set; }

    public Enemy(EnemyConfig config) 
    {
        _health = new Health(config.Health,config.Health);
        DamageCharacter = config.DamagePlayer;
    }

    public void Move(float direction)
    => DirectionMoveX = direction;

    public void Damage(int damage)
    => _health.TakeDamage(damage);

    public void Enable()
    {
        _health.onDeath += OnDeath;
    }

    public void Disable()
    {
        _health.onDeath -= OnDeath;
    }

    private void OnDeath()
    => onDeath.Invoke();
}
