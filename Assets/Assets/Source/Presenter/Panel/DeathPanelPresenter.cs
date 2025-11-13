using Zenject;

public class DeathPanelPresenter : IDeathPanelPresenter
{
    private ICharacterHealthPresenter _healthPresenter;
    private IGameplayPanel _gameplayPanel;
    private GameplayEntryPoint _gameplayEntryPoint;

    [Inject]
    private void Construnct(ICharacterHealthPresenter characterHealthPresenter,IGameplayPanel gameplayPanel,GameplayEntryPoint gameplayEntryPoint) 
    {
        _gameplayEntryPoint = gameplayEntryPoint;
        _healthPresenter = characterHealthPresenter;
        _gameplayPanel = gameplayPanel;
    }

    public void Reset() 
    {
        _healthPresenter.Heal();
        _gameplayEntryPoint.CreatLevel();
        _gameplayPanel.Show();
    }
}