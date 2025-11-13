using UnityEngine;
using Zenject;

public class StartMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private LevelsPanelView _levelPanelView;
    [SerializeField] private StartPanelView _startPanelView;

    private IStartPanelPresenter _startPanelPresenter;

    [Inject]
    private void Construct(IStartPanelPresenter startPanelPresenter) 
    {
        _startPanelPresenter = startPanelPresenter;
    }

    private void Awake()
    {
        _startPanelView.Show();
        _startPanelPresenter.BindLevelsPanel(_levelPanelView);
    }
}