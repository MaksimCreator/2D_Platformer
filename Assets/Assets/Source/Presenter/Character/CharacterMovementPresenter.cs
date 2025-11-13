using UnityEngine;
using Zenject;

public class CharacterMovementPresenter : ICharacterMovementPresenter
{
    private readonly Character _character;
    private readonly IGroundSystem _characterChecker;
    private readonly ICharacterAnimation _characterAnimation;

    public float PositionX => _character.PositionX;

    public Vector2 Direction => _character.Direction;

    public bool IsGrounded => _characterChecker.IsGrounded();

    [Inject]
    public CharacterMovementPresenter(Character character,IGroundSystem characterChecker,ICharacterAnimation characterAnimation) 
    {
        _character = character;
        _characterChecker = characterChecker;
        _characterAnimation = characterAnimation;
    }

    public void Move(float direction) 
    {
        _character.Move(direction);

        if (_character.IsJump == false && direction != 0)
            _characterAnimation.Run();
        else if (_character.IsJump == false && direction == 0)
            _characterAnimation.Idel();
    }

    public void Jump()
    => _character.Jump();

    public void Update(float delta)
    {
        if (_character.IsJump)
            _characterAnimation.Jump();
    }

    public void FixedUpdate()
    => _character.UpdateGroundState(IsGrounded);
}