using System;

public interface IInputRouter : IUpdateble,IControl
{
    event Action<float> onMove;
    event Action onJump;
}
