using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Zenject;

public class CharacterHealthPresenter  : ICharacterHealthPresenter
{
    private readonly Character _character;
    private readonly EnemyLookup _enemyCatalog;
    private readonly MoneyCatalog _moneyCatalog;

    private readonly IEnemyViewFactory _enemyViewFactory;
    private readonly ICharacterViewFactory _characterViewFactory;
    private readonly IMoneyViewFactory _moneyViewFactory;

    private readonly IGameplayPanel _gameplayPanel;
    private readonly IDeathPanel _deathPanel;
    
    private readonly ICharacterAnimation _characterAnimation;

    [Inject]
    public CharacterHealthPresenter(Character character,
        EnemyLookup enemyCatalog,
        MoneyCatalog moneyCatalog,
        ICharacterAnimation characterAnimation,
        IGameplayPanel gameplayPanel,
        IDeathPanel deathPanel,
        IEnemyViewFactory enemyViewFactory,
        ICharacterViewFactory characterViewFactory,
        IMoneyViewFactory moneyViewFactory)
    { 
        _character = character;
        _enemyCatalog = enemyCatalog;
        _moneyCatalog = moneyCatalog;

        _enemyViewFactory = enemyViewFactory;
        _characterViewFactory = characterViewFactory;
        _moneyViewFactory = moneyViewFactory;
        
        _gameplayPanel = gameplayPanel;
        _deathPanel = deathPanel;

        _characterAnimation = characterAnimation;
    }

    public void Death()
    => _character.Death();

    public void Disable()
    {
        _character.onDeath -= OnDeath;
    }

    public void Enable()
    {
        _character.onDeath += OnDeath;
    }

    public void Heal() 
    {
        _character.Reset();
    }

    public async UniTaskVoid TakeDamage(IInputRouter inputRouter, IEnemyView enemyView) 
    {
        inputRouter.Disable();

        TypeMove typeMove;

        if (_character.PositionX > enemyView.PositionX)
            typeMove = TypeMove.Right;
        else
            typeMove = TypeMove.Left;

        Enemy enemy = _enemyCatalog.GetEnemy(enemyView);
        _character.TakeDamage(enemy.DamageCharacter, typeMove);

        await _characterAnimation.TakeDamage();

        if(_character.IsDeath == false)
            inputRouter.Enable();
    }

    private void OnDeath() 
    {
        IReadOnlyList<Enemy> enemies = _enemyCatalog.Enemies;
        IReadOnlyList<Money> money = _moneyCatalog.Moneys;
        
        _characterViewFactory.Destroy();

        for (int i = 0; i < enemies.Count; i++)
            _enemyViewFactory.Destroy(enemies[i]);

        for (int i = 0; i < money.Count; i++)
            _moneyViewFactory.Destroy(money[i]);

        _gameplayPanel.Hide();
        _deathPanel.Show();
    }
}