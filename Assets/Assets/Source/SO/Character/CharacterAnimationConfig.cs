using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAnimationConfig", menuName = "Config/CharacterAnimation", order = 50)]
public class CharacterAnimationConfig : ScriptableObject
{
    [SerializeField] private string _nameIdelCharacterAnimation;
    [SerializeField] private string _nameRunCharacterAnimation;
    [SerializeField] private int _countOfBlinks = 3;
    [SerializeField] private float _durationDisappearSecond = 0.35f;
    [SerializeField] private float _durationAppearsSecond = 0.35f;

    public int IdelCharacterAnimation => Animator.StringToHash(_nameIdelCharacterAnimation);
    public int RunCharacterAnimation => Animator.StringToHash(_nameRunCharacterAnimation);
    public int CountBlinks => _countOfBlinks;
    public float DurationDisappearSecond => _durationDisappearSecond;
    public float DurationAppearsSecond => _durationAppearsSecond;
}