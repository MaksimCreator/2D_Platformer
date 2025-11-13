using System;

public class Health 
{
    private const int _minHealth = 0;
    private readonly int _maxHealth;

    public event Action onDeath;
    public event Action onTakeDamage;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
    public int CurentHealth { get; private set; }

    public Health(int maxHealth, int curentHealth)
    {
        _maxHealth = maxHealth;
        CurentHealth = curentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new InvalidOperationException(nameof(damage));

        if (CurentHealth - damage <= MinHealth)
        {
            CurentHealth = 0;
            onDeath?.Invoke();
        }
        else
        {
            CurentHealth -= damage;
            onTakeDamage?.Invoke();
        }

    }

    protected void Heal(int heal) 
    {
        if(heal < 0)
            throw new InvalidOperationException($"Heal {heal}");

        if (CurentHealth == MaxHealth)
            return;

        if(CurentHealth + heal > MaxHealth)
            CurentHealth = MaxHealth;
        else
            CurentHealth += heal;
    }
}
