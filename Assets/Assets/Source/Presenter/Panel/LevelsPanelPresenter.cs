using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class LevelsPanelPresenter 
{
    private readonly int _firstLevel = 1;
    private readonly int _unlockedLevel;

    private readonly IButtonAnimation _buttonAnimation;

    public bool IsEnterButton { get; private set; } = false;

    public int UnlockedLevel => _unlockedLevel - 1;

    [Inject]
    private LevelsPanelPresenter(IButtonAnimation buttonAnimation,UnlockedLevelConfig config, UnlockedLevelLoader unlockedLevelLoader)
    {
        _buttonAnimation = buttonAnimation;
        _unlockedLevel = unlockedLevelLoader.Load().Value;
        _firstLevel = config.FirstLevel;
    }

    public async UniTask EnterLevel(int indexButton,Button button) 
    {
        int level = _firstLevel + indexButton;
        IsEnterButton = true;
        
        await _buttonAnimation.EnterAnimation(button);
        IsEnterButton = false;

        SceneManager.LoadScene(level);
    }
}