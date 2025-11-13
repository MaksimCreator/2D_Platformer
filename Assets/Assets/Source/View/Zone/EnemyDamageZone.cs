using UnityEngine;

public class EnemyDamageZone : MonoBehaviour 
{
    [SerializeField] private EnemyView _enemyView;

    public IEnemyView EnemyView => _enemyView;
}