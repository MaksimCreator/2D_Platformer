using UnityEngine;

[CreateAssetMenu(fileName = "AIConfig", menuName = "Config/AI", order = 50)]
public class EnemyConfig : ScriptableObject 
{
    [SerializeField, Range(1, 3)] private int _health = 1;
    [SerializeField] private int _damagePlayer = 1;

    public int Health => _health;

    public int DamagePlayer => _damagePlayer;
}