using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyViewFactory : MonoBehaviour , IEnemyViewFactory
{
    [SerializeField] private EnemyView _enemy;

    private readonly Dictionary<Enemy, EnemyView> _views = new();
    private readonly Dictionary<Enemy,IEnemyPresenter> _presenters = new();
    private readonly Dictionary<Enemy, DecisionEnemy> _decisions = new();

    private DiContainer _container;

    private DecisionEnemyCatalog _decisionEnemyCatalog;
    private EnemyPresenterCatalog _enemyPresenterCatalog;
    private EnemyCatalog _enemyCatalog;

    private EnemyLookup _enemyLookup;
    private EnemyPresenterLookup _enemyPresenterLookup;

    private EnemyAnimationConfig _enemyAnimationConfig;
    private EnemyConfig _enemyConfig;

    [Inject]
    private void Construct(DiContainer container,
        EnemyAnimationConfig enemyAnimationConfig,
        EnemyConfig enemyConfig,
        DecisionEnemyCatalog decisionEnemyCatalog,
        EnemyPresenterCatalog enemyPresenterCatalog,
        EnemyCatalog enemyCatalog,
        EnemyLookup enemyLookup,
        EnemyPresenterLookup enemyPresenterLookup) 
    {
        _container = container;

        _enemyAnimationConfig = enemyAnimationConfig;
        _enemyConfig = enemyConfig;

        _decisionEnemyCatalog = decisionEnemyCatalog;
        _enemyPresenterCatalog = enemyPresenterCatalog;
        _enemyCatalog = enemyCatalog;

        _enemyLookup = enemyLookup;
        _enemyPresenterLookup = enemyPresenterLookup;
    }

    public void Creat(Vector3 position) 
    {
        EnemyView view = Instantiate(_enemy,position,Quaternion.identity);

        Animator animator = view.GetComponent<Animator>();
        EnemyBlackBoard blackBoard = _container.Resolve<EnemyBlackBoard>();

        Enemy enemy = new Enemy(_enemyConfig);
        IEnemyAnimator enemyAnimator = new EnemyAnimator(_enemyAnimationConfig,animator);
        IEnemyPresenter presenter = new EnemyPresenter(enemyAnimator,this,enemy);
        DecisionEnemy decision = new DecisionEnemy(blackBoard, enemy);

        _decisionEnemyCatalog.Add(decision);
        _enemyPresenterCatalog.Add(presenter);
        _enemyCatalog.Add(enemy);

        _enemyLookup.Registary(view, enemy);
        _enemyPresenterLookup.Registary(view, presenter);

        _views.Add(enemy, view);
        _presenters.Add(enemy,presenter);
        _decisions.Add(enemy, decision);

        view.Construct(presenter);
    }

    public void Destroy(Enemy enemy)
    {
        EnemyView view = _views[enemy];
        DecisionEnemy decision = _decisions[enemy];
        IEnemyPresenter presenter = _presenters[enemy];

        _views.Remove(enemy);
        _enemyLookup.Remove(view);
        _enemyPresenterCatalog.Remove(presenter);
        _enemyCatalog.Remove(enemy);
        _decisionEnemyCatalog.Remove(decision);
        
        Destroy(view.gameObject);
    }
}
