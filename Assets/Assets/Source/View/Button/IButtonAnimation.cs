using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public interface IButtonAnimation 
{
    UniTask EnterAnimation(Button button);
}
