using UnityEngine;

[CreateAssetMenu(fileName = "UnlockedLevelConfig", menuName = "Config/UnlockedLevel", order = 50)]
public class UnlockedLevelConfig : ScriptableObject
{
    private const int _increment = 1;
    
    [SerializeField] private int _firstLevel = 1;
    [SerializeField] private int _maxLevel = 4;

    public int Increment => _increment;

    public int FirstLevel => _firstLevel;

    public int MaxLevel => _maxLevel;
}