using UnityEngine;

public abstract class GameLoop : MonoBehaviour
{
    private bool _isEnable;

    private IControl[] _controls;
    private IUpdateble[] _updatebles;
    private ILateUpdate[] _lateUpdates;
    private IFixedUpdateble[] _fixedUpdates;

    private void Update()
    {
        if (_updatebles == null)
            _updatebles = GetUpdatebles();

        for (int i = 0; i < _updatebles.Length; i++)
            _updatebles[i].Update(Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        if (_fixedUpdates == null)
            _fixedUpdates = GetFixedUpdatebles();

        for (int i = 0; i < _fixedUpdates.Length; i++)
            _fixedUpdates[i].FixedUpdate();
    }

    private void LateUpdate()
    {
        if (_lateUpdates == null)
            _lateUpdates = GetLateUpdates();

        for (int i = 0; i < _lateUpdates.Length; i++)
            _lateUpdates[i].LateUpdate();
    }

    public void OnEnable()
    {
        if (_isEnable)
            return;

        if (_controls == null)
            _controls = GetControls();

        for (int i = 0; i < _controls.Length; i++)
            _controls[i].Enable();

        _isEnable = true;
    }

    public void OnDisable()
    {
        if (_isEnable == false)
            return;

        if (_controls == null)
            _controls = GetControls();

        for (int i = 0; i < _controls.Length; i++)
            _controls[i].Disable();

        _isEnable = false;
    }

    protected virtual IControl[] GetControls()
    => new IControl[0];

    protected virtual IUpdateble[] GetUpdatebles()
    => new IUpdateble[0];

    protected virtual ILateUpdate[] GetLateUpdates()
    => new ILateUpdate[0];

    protected virtual IFixedUpdateble[] GetFixedUpdatebles()
    => new IFixedUpdateble[0];
}