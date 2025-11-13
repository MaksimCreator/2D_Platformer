using UnityEngine;

[CreateAssetMenu(fileName = "MoneyConfig", menuName = "Config/Money", order = 50)]
public class MoneyConfig : ScriptableObject 
{
    [SerializeField] private int _money = 1;

    public int CountAddMoney => _money;
}