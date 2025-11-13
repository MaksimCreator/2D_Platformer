public class EnemyPresenter : IEnemyPresenter
{
    private readonly IEnemyViewFactory _enemyViewFactory;
    private readonly IEnemyAnimator _enemyAnimator;
    private readonly Enemy _enemy;

    public float DirectionX => _enemy.DirectionMoveX;

    public EnemyPresenter(IEnemyAnimator enemyAnimator,IEnemyViewFactory enemyViewFactory, Enemy enemy)
    {
        _enemyAnimator = enemyAnimator;
        _enemyViewFactory = enemyViewFactory;
        _enemy = enemy;
    }

    public void Update(float delta)
    {
        if (_enemy.DirectionMoveX != 0)
            _enemyAnimator.Run();
        else
            _enemyAnimator.Idel();
    }

    public void Enable()
    {
        _enemy.onDeath += OnDeath;
    }

    public void Disable()
    {
        _enemy.onDeath -= OnDeath;
    }

    public void TakeDamage(int damage)
    => _enemy.Damage(damage);

    private void OnDeath()
    => _enemyViewFactory.Destroy(_enemy);
}