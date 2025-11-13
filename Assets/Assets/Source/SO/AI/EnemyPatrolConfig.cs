using UnityEngine;

[CreateAssetMenu(fileName = "AIPatrolConfig", menuName = "Config/AIPatrol", order = 50)]
public class EnemyPatrolConfig : ScriptableObject 
{
    [SerializeField] private float _leftMoveUnit;
    [SerializeField] private float _rightMoveUnit;
    [SerializeField] private float _speed;

    public float LeftMoveUnit => _leftMoveUnit;
    public float RightMoveUnit => _rightMoveUnit;
    public float Speed => _speed;
}
