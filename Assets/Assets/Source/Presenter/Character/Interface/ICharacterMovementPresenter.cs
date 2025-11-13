using UnityEngine;

public interface ICharacterMovementPresenter : IUpdateble,IFixedUpdateble
{
    void Move(float dierction);
    void Jump();

    Vector2 Direction { get; }
    float PositionX { get; }
}
