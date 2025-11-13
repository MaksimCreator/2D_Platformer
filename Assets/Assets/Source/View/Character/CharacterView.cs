using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _characterRb;

    private IInputRouter _input;

    private ICharacterMovementPresenter _movementPresenter; 
    private ICharacterHealthPresenter _healthPresenter;
    private ICharacterAttackPresenter _attackPresenter;

    private Transform _characterTransform;
    private SpriteRenderer _characterSpriteRenderer;

    [Inject]
    private void Construct(IInputRouter input,
        ICharacterMovementPresenter movementPresenter,
        ICharacterHealthPresenter characterHealthPresenter,
        ICharacterAttackPresenter characterAttackPresenter)
    {
        _input = input;

        _movementPresenter = movementPresenter;
        _healthPresenter = characterHealthPresenter;
        _attackPresenter = characterAttackPresenter;

        _characterTransform = _characterRb.transform;
        _characterSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.onMove += _movementPresenter.Move;
        _input.onJump += _movementPresenter.Jump;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.onMove -= _movementPresenter.Move;
        _input.onJump -= _movementPresenter.Jump;
    }

    private void Update()
    {
        _characterTransform.position = Vector3.right * _movementPresenter.PositionX + Vector3.up * _characterTransform.position.y;
        _characterRb.AddForce(Vector2.up * _movementPresenter.Direction.y, ForceMode2D.Impulse);

        if(_movementPresenter.Direction.x < 0)
            _characterSpriteRenderer.flipX = true;
        else if (_movementPresenter.Direction.x > 0)
            _characterSpriteRenderer.flipX = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out EnemyView enemyView))
            _healthPresenter.TakeDamage(_input,enemyView);

        if (collision.collider.gameObject.TryGetComponent(out EnemyDamageZone zone))
            _attackPresenter.TakeDamageEnemy(zone.EnemyView);
    }
}
