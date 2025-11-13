public interface IEnemyView 
{
    public float PositionX { get; }

    void Construct(IEnemyPresenter presenter);
}