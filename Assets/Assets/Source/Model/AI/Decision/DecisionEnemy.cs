public class DecisionEnemy : IUpdateble
{
    private readonly PatrolBehavior _patrolBehavior;
    private readonly Enemy _enemy;

    public DecisionEnemy(EnemyBlackBoard catalog,Enemy enemy) 
    {
        EnemyPatrolConfig config = catalog.ConfigEnemy;
        _patrolBehavior = new PatrolBehavior(config.LeftMoveUnit, config.RightMoveUnit, config.Speed);
        _enemy = enemy;
    }

    public void StartMove()
    => _patrolBehavior.StartMove(TypeMove.Left);

    public void Update(float delta)
    { 
        _patrolBehavior.Update(delta);
        _enemy.Move(_patrolBehavior.Direction);
    }
}
