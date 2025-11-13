using System;

public class PatrolBehavior 
{
    private const int INVERSION = -1;

    private readonly float _leftMove;
    private readonly float _rightMove;
    private readonly float _speed;

    private bool _canInitPointMove;
    private float _deltaDirection;
    private float _directionMove;
    private bool _isFirstMove;
    private float _pointMove;
    private float _distance;
    private bool _isInit;

    public float Direction { get;private set; }

    public PatrolBehavior(float leftMove,float rightMove,float speed) 
    {
        _leftMove = leftMove;
        _rightMove = rightMove;
        _speed = speed;
    }

    public void StartMove(TypeMove typeFirstMove)
    {
        _directionMove = (int)typeFirstMove;

        _isInit = true;
        _isFirstMove = true;
        _canInitPointMove = true;
    }

    public void Update(float delta) 
    {
        if (_isInit == false)
            return;

        if (_canInitPointMove) 
        {
            InitPointMove();
            _canInitPointMove = false;
        }
            
        Move(delta);
    }

    private void Move(float delta) 
    {
        _deltaDirection = _speed * delta;

        if (_distance + _deltaDirection >= _pointMove)
        {
            _deltaDirection = _pointMove - _distance;
            _distance = 0;

            Direction = _deltaDirection * _directionMove;

            _directionMove *= INVERSION;
            _canInitPointMove = true;

            if (_isFirstMove)
                _isFirstMove = false;
        }
        else
        {
            _distance += _deltaDirection;
            Direction = _deltaDirection * _directionMove;
        }
    }

    private void InitPointMove()
    {
        if (_isFirstMove)
        {
            if (_directionMove > 0)
                _pointMove = _rightMove;
            else if (_directionMove < 0)
                _pointMove = _leftMove;
            else
                throw new InvalidOperationException();
        }
        else
        {
            _pointMove = _leftMove + _rightMove;
        }
    }
}
