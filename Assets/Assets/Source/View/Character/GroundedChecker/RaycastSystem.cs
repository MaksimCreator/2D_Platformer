using UnityEngine;
using Zenject;

public class RaycastSystem : MonoBehaviour,IGroundSystem
{
    [SerializeField] private Transform _groundCheckPoint;

    [SerializeField] private float _groundCheckDistance = 0.1f;

    private GameConfig _gameConfig;

    [Inject]
    private void Construct(GameConfig config) 
    {
        _gameConfig = config;
    }

    public bool IsGrounded()
    => Physics2D.Raycast(_groundCheckPoint.position,Vector2.down,_groundCheckDistance, _gameConfig.GroundLayer);
}