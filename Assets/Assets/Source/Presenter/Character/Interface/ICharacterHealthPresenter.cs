using Cysharp.Threading.Tasks;

public interface ICharacterHealthPresenter : IControl
{
    void Death();
    void Heal();
    UniTaskVoid TakeDamage(IInputRouter inputRouter, IEnemyView enemyView);
}