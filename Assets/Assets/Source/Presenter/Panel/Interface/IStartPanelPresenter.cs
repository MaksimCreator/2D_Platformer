using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public interface IStartPanelPresenter 
{
    void BindLevelsPanel(ILevelsPanelView levelsPanel);
    UniTask Play(Button button);
    UniTask EnterLevels(Button button);

    bool IsEnterButton { get; }
}
