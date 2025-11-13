using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;
public class StartPanelPresenter : IStartPanelPresenter
{
    private readonly IButtonAnimation _buttonAnimation;
    private readonly GameDataStorage _gameDataStorage;

    private ILevelsPanelView _levelsPanel;

    public bool IsEnterButton { get; private set; } = false;

    [Inject]
    public StartPanelPresenter(IButtonAnimation buttonAnimation,GameDataLoader gameDataLoder) 
    {
        _buttonAnimation = buttonAnimation;
        _gameDataStorage = gameDataLoder.Load();
    }

    public void BindLevelsPanel(ILevelsPanelView levelsPanel) 
    {
        _levelsPanel = levelsPanel;
    }

    public async UniTask Play(Button button) 
    {
        IsEnterButton = true;
        await _buttonAnimation.EnterAnimation(button);
        IsEnterButton = false;

        SceneManager.LoadScene(_gameDataStorage.Value);
    }

    public async UniTask EnterLevels(Button button) 
    {
        IsEnterButton = true;
        await _buttonAnimation.EnterAnimation(button);
        IsEnterButton = false;

        _levelsPanel.Show();
    }
}
