using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/Game", order = 50)]
public class GameConfig : ScriptableObject
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _moneyLayer;

    public LayerMask GroundLayer => _groundLayer;

    public LayerMask MoneyLayer => _moneyLayer;
}