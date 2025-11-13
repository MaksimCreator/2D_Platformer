using Zenject;

public class CharacterAttackPresenter : ICharacterAttackPresenter
{
    private readonly Character _character;
    private readonly EnemyPresenterLookup _enemyPresenterLookup;

    [Inject]
    private CharacterAttackPresenter(Character character,EnemyPresenterLookup enemyPresenterLookup) 
    {
        _character = character;
        _enemyPresenterLookup = enemyPresenterLookup;
    }

    public void TakeDamageEnemy(IEnemyView view) 
    {
        IEnemyPresenter presenter = _enemyPresenterLookup.GetPresenter(view);
        presenter.TakeDamage(_character.Damage);
    }
}
