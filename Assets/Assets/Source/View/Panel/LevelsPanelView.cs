using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class LevelsPanelView : Panel, ILevelsPanelView
{
    [SerializeField] private List<Button> _levels = new();

    private LevelsPanelPresenter _presenter;

    private bool _isInteractableButtons = true;

    [Inject]
    private void Construct(LevelsPanelPresenter presenter) 
    {
        _presenter = presenter;
    }

    private void OnEnable()
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            int indexButton = i;
            Button button = _levels[indexButton];
            _levels[i].onClick.AddListener(() => EnterLevel(indexButton,button));
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _levels.Count; i++)
            _levels[i].onClick.RemoveAllListeners();
    }

    private void Update()
    {
        if (_presenter.IsEnterButton && _isInteractableButtons == true)
        {
            for (int i = 0; i < _presenter.UnlockedLevel; i++)
                _levels[i].interactable = false;
                
            _isInteractableButtons = false;
        }
        else if(_presenter.IsEnterButton == false &&_isInteractableButtons == false)
        {
            for (int i = 0; i < _presenter.UnlockedLevel; i++)
                _levels[i].interactable = true;

            _isInteractableButtons = true;
        }
    }

    private async UniTaskVoid EnterLevel(int index,Button button) 
    {
        await _presenter.EnterLevel(index, button);
        Hide();
    }
}