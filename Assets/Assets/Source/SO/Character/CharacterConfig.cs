using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName ="Config/Character")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _recoilDistanceUnit = 2;
    [SerializeField] private int _damage = 1;

    public int Health => _health;

    public int RecoilDistance => _recoilDistanceUnit;

    public int Damage => _damage;
}