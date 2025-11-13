using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [Header("Unity")]
    [SerializeField] private Sprite _jumpSprite;
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private SpriteRenderer _characterRenderer;

    [Header("Config")]

    [SerializeField] private CharacterMovementConfig _characterMovementConfig;
    [SerializeField] private CharacterAnimationConfig _characterAnimationConfig;
    [SerializeField] private CharacterConfig _characterConfig;

    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private EnemyPatrolConfig _enemyPatrolConfig;
    [SerializeField] private EnemyAnimationConfig _enemyAnimationConfig;

    [SerializeField] private MoneyConfig _moneyConfig;

    [SerializeField] private GameConfig _gameConfig;

    [Header("Sytem")]

    [SerializeField] private RaycastSystem _characterGroundChecker;

    [Header("Factory")]

    [SerializeField] private EnemyViewFactory _enemyViewFactory;
    [SerializeField] private MoneyViewFactory _moneyViewFactory;
    [SerializeField] private CharacterViewFactory _characterViewFactory;

    [Header("Panel")]

    [SerializeField] private GameplayPanel _gameplayPanel;
    [SerializeField] private DeathPanel _deathPanel;

    [Header("EntryPoint")]

    [SerializeField] private GameplayEntryPoint _gameplayEntryPoint;

    public override void InstallBindings()
    {
        RegistarySO();
        RegistaryPanel();
        RegistaryInput();
        RegistarySystem();
        RegistaryLookup();
        RegistaryEntity();
        RegistaryCatalog();
        RegistaryMovement();
        RegistaryAnimation();
        RegistaryPresenter();
        RegistartBlackBoard();
        RegistaryEntryPoint();
        RegistaryViewFactory();
    }

    private void RegistaryPanel()
    {
        Container.Bind<IGameplayPanel>()
            .To<GameplayPanel>()
            .FromInstance(_gameplayPanel)
            .AsCached();
        
        Container.Bind<IDeathPanel>()
            .To<DeathPanel>()
            .FromInstance(_deathPanel)
            .AsCached();
    }

    private void RegistaryEntryPoint() 
    {
        Container.Bind<GameplayEntryPoint>()
            .FromInstance(_gameplayEntryPoint)
            .AsCached();
    }

    private void RegistaryViewFactory() 
    {
        Container.Bind<IEnemyViewFactory>()
            .To<EnemyViewFactory>()
            .FromInstance(_enemyViewFactory)
            .AsSingle();

        Container.Bind<IMoneyViewFactory>()
            .To<MoneyViewFactory>()
            .FromInstance(_moneyViewFactory)
            .AsCached();

        Container.Bind<ICharacterViewFactory>()
            .To<CharacterViewFactory>()
            .FromInstance(_characterViewFactory)
            .AsCached();
    }

    private void RegistarySO() 
    {
        Container.Bind<CharacterConfig>()
            .FromInstance(_characterConfig)
            .AsSingle();

        Container.Bind<CharacterMovementConfig>()
            .FromInstance(_characterMovementConfig)
            .AsSingle();

        Container.Bind<EnemyPatrolConfig>()
            .FromInstance(_enemyPatrolConfig)
            .AsSingle();

        Container.Bind<EnemyConfig>()
            .FromInstance(_enemyConfig)
            .AsSingle();

        Container.Bind<EnemyAnimationConfig>()
            .FromInstance(_enemyAnimationConfig)
            .AsSingle();

        Container.Bind<MoneyConfig>()
            .FromInstance(_moneyConfig)
            .AsSingle();

        Container.Bind<GameConfig>()
            .FromInstance(_gameConfig)
            .AsSingle();
    }

    private void RegistaryMovement() 
    {
        Container.Bind<CharacterMovement>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryPresenter() 
    {
        Container.Bind<ICharacterMovementPresenter>()
            .To<CharacterMovementPresenter>()
            .FromNew()
            .AsCached();

        Container.Bind<IGameplayPanelPresenter>()
            .To<GameplayPanelPersenter>()
            .FromNew()
            .AsCached();

        Container.Bind<ICharacterHealthPresenter>()
            .To<CharacterHealthPresenter>()
            .FromNew()
            .AsCached();

        Container.Bind<ICharacterMoneyPresenter>()
            .To<CharacterMoneyPresenter>()
            .FromNew()
            .AsCached();

        Container.Bind<IDeathPanelPresenter>()
            .To<DeathPanelPresenter>()
            .FromNew()
            .AsCached();

        Container.Bind<ICharacterAttackPresenter>()
            .To<CharacterAttackPresenter>()
            .FromNew()
            .AsCached();
    }

    private void RegistarySystem() 
    {
        Container.Bind<IGroundSystem>()
            .To<RaycastSystem>()
            .FromInstance(_characterGroundChecker)
            .AsCached();
    }

    private void RegistaryInput() 
    {
        Container.Bind<IInputRouter>()
            .To<InputRouter>()
            .FromNew()
            .AsCached();
    }

    private void RegistaryAnimation() 
    {
        ICharacterAnimation animation = new CharacterAnimation(_jumpSprite, _characterAnimationConfig)
            .BindCahracterData(_characterRenderer, _characterAnimator);

        Container.Bind<ICharacterAnimation>()
            .FromInstance(animation)
            .AsCached();

    }

    private void RegistaryEntity() 
    {
        Container.Bind<Character>()
            .FromNew()
            .AsSingle();

        Container.Bind<Enemy>()
            .FromNew()
            .AsTransient();

        Container.Bind<Money>()
            .FromNew()
            .AsTransient();
    }

    private void RegistaryCatalog() 
    {
        Container.Bind<DecisionEnemyCatalog>()
            .FromNew()
            .AsSingle();

        Container.Bind<EnemyPresenterCatalog>()
            .FromNew()
            .AsSingle();

        Container.Bind<MoneyCatalog>()
            .FromNew()
            .AsSingle();

        Container.Bind<EnemyCatalog>()
            .FromNew()
            .AsSingle();
    }

    private void RegistartBlackBoard() 
    {
        Container.Bind<EnemyBlackBoard>()
            .FromNew()
            .AsTransient();
    }

    private void RegistaryLookup() 
    {
        Container.Bind<EnemyLookup>()
            .FromNew()
            .AsSingle();

        Container.Bind<EnemyPresenterLookup>()
            .FromNew()
            .AsSingle();
    }
}