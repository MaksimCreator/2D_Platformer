using TMPro;
using UnityEngine;
using Zenject;

public class GameplayPanel : Panel, IGameplayPanel
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _health;

    private IGameplayPanelPresenter _gameplayPresenter;

    [Inject]
    private void Construnct(IGameplayPanelPresenter gameplayPresenter) 
    {
        _gameplayPresenter = gameplayPresenter;
    }

    private void Update()
    {
        _score.text = $"Score: {_gameplayPresenter.Score}";
        _health.text = $"{_gameplayPresenter.MaxHealth}/{_gameplayPresenter.Health}";
    }
}