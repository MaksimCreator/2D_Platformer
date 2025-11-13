using System;
using UnityEngine.InputSystem;

public class InputRouter : IInputRouter
{
    private readonly CharacterInput _input = new CharacterInput();

    public event Action<float> onMove;
    public event Action onJump;

    private bool _isEnable;

    public void Disable()
    {
        _isEnable = false;
        _input.Disable();
        _input.Dispose();
    }

    public void Enable()
    {
        _isEnable = true;
        _input.Enable();
    }

    public void Update(float delta) 
    {
        if (_isEnable == false)
            return;

        float direction = _input.Move.Run.ReadValue<float>();
        onMove.Invoke(direction);

        if (CanJump())
            onJump.Invoke();
    }

    private bool CanJump()
    => _input.Move.Jump.phase == InputActionPhase.Performed;
}
