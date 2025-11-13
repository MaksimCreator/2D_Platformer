public class CharacterHealth : Health
{
    private readonly int _maxHealth;

    public CharacterHealth(int maxHealth,int curentHealth) : base(maxHealth, curentHealth)
    {
        _maxHealth = maxHealth;
    }

    public void Death()
    => TakeDamage(_maxHealth);

    public void Heal()
    => Heal(_maxHealth);
}