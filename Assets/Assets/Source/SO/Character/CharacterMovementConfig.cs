using UnityEngine;

[CreateAssetMenu(fileName = "CharacterMovementConfig", menuName = "Config/CharacterMovement", order = 50)]
public class CharacterMovementConfig : ScriptableObject
{
    [SerializeField] private float _speedMoveGround;
    [SerializeField] private float _forceJump;

    public float SpeedMove => _speedMoveGround;
    public float ForceJump => _forceJump;
}