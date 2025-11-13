public interface IEnemyPresenter : IUpdateble,IControl
{
    void TakeDamage(int damage);

    float DirectionX { get; }
}
