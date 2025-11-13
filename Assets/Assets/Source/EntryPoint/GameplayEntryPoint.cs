using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointSpawnEnemy;
    [SerializeField] private List<Transform> _pointSpawnMoney;
    [SerializeField] private Transform _characterCreatPoint;

    private DecisionEnemyCatalog _catalog;
    
    private IEnemyViewFactory _enemyViewFactory;
    private ICharacterViewFactory _characterViewFactory;
    private IMoneyViewFactory _moneyViewFactory;
    
    private IDeathPanelPresenter _deathPanelPresenter;

    private IGameplayPanel _gameplayPanel;
    private DeathPanel _deathPanel;

    [Inject]
    private void Construct(IEnemyViewFactory factory,
        DecisionEnemyCatalog decisionEnemyCatalog,
        IMoneyViewFactory moneyViewFactory,
        ICharacterViewFactory characterViewFactory,
        IGameplayPanel gameplayPanel,
        IDeathPanelPresenter deathPanelPresenter,
        IDeathPanel deathPanel) 
    {
        _enemyViewFactory = factory;
        _catalog = decisionEnemyCatalog;
        _moneyViewFactory = moneyViewFactory;
        _characterViewFactory = characterViewFactory;
        _gameplayPanel = gameplayPanel;
        _deathPanelPresenter = deathPanelPresenter;
        _deathPanel = deathPanel as DeathPanel;
        _deathPanelPresenter = deathPanelPresenter;
    }

    private void Awake()
    {
        _deathPanel.BindPresenter(_deathPanelPresenter);
        CreatLevel();
        _gameplayPanel.Show();
    }

    public void CreatLevel() 
    {
        _characterViewFactory.Creat(_characterCreatPoint.position);

        for (int i = 0; i < _pointSpawnEnemy.Count; i++)
            _enemyViewFactory.Creat(_pointSpawnEnemy[i].position);

        for (int i = 0; i < _pointSpawnMoney.Count; i++)
            _moneyViewFactory.Creat(_pointSpawnMoney[i].position);

        _catalog.StartMove();
    }
}