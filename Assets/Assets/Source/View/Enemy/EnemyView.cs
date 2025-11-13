using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyView : MonoBehaviour,IEnemyView
{
    [SerializeField] private SpriteRenderer _enemySpriteRenderer;

    private Transform _transform;
    private IEnemyPresenter _presenter;

    private bool _isInit = false;

    public float PositionX => _transform.position.x;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    { 
        _transform.position += _presenter.DirectionX * Vector3.right;
        
        if(_presenter.DirectionX > 0)
            _enemySpriteRenderer.flipX = false;
        else 
            _enemySpriteRenderer.flipX = true;
    }

    public void Construct(IEnemyPresenter presenter)
    {
        if (_isInit)
            return;

        _isInit = true;
        _presenter = presenter;
    }
}
