using Zenject;

public class GameplayLoop : GameLoop
{
    private IControl[] _controls;
    private IUpdateble[] _updatebles;
    private ILateUpdate[] _lateUpdates;
    private IFixedUpdateble[] _fixedUpdates;

    [Inject]
    private void Construct(IInputRouter input, 
        ICharacterMovementPresenter characterMovementPresenter,
        ICharacterHealthPresenter characterHealthPresenter,
        DecisionEnemyCatalog decisionEnemyCatalog,
        EnemyPresenterCatalog enemyPresenterCatalog,
        EnemyCatalog enemyCatalog,
        Character character)
    {
        _controls = new IControl[]
        {
            input,
            enemyCatalog,
            character,
            decisionEnemyCatalog,
            characterHealthPresenter,
            enemyPresenterCatalog
        };
        _updatebles = new IUpdateble[]
        {
            input,
            characterMovementPresenter,
            character,
            decisionEnemyCatalog,
            enemyPresenterCatalog
        };
        _lateUpdates = new ILateUpdate[]
        {
            character
        };
        _fixedUpdates = new IFixedUpdateble[]
        {
            characterMovementPresenter
        };
    }

    protected override IControl[] GetControls()
    => _controls;

    protected override IUpdateble[] GetUpdatebles()
    => _updatebles;

    protected override ILateUpdate[] GetLateUpdates()
    => _lateUpdates;

    protected override IFixedUpdateble[] GetFixedUpdatebles()
    => _fixedUpdates;
}