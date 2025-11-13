using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartPanelView : Panel
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _levels;

    private IStartPanelPresenter _presenter;

    private bool _isInteractableButtons = true;

    [Inject]
    private void Construct(IStartPanelPresenter presenter) 
    {
        _presenter = presenter;
    }

    private void OnEnable()
    {
        _play.onClick.AddListener(Play);
        _levels.onClick.AddListener(EnterPanelLevels);
    }

    private void OnDisable()
    {
        _play.onClick.RemoveAllListeners();
        _levels.onClick.RemoveAllListeners();
    }

    private void Update() 
    {
        if (_presenter.IsEnterButton)
        {
            _play.interactable = false;
            _levels.interactable = false;
            _isInteractableButtons = false;
        }
        else 
        {
            _play.interactable = true;
            _levels.interactable = true;
            _isInteractableButtons = true;
        }
    }

    private void Play()
    => Play(_play);

    private void EnterPanelLevels()
    => EnterPanelLevels(_levels);

    private async UniTaskVoid Play(Button button) 
    {
        await _presenter.Play(button);
        Hide();
    }

    private async UniTaskVoid EnterPanelLevels(Button button) 
    {
        await _presenter.EnterLevels(button);
        Hide();
    }

}