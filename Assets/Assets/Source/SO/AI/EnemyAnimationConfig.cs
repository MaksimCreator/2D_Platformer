using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAnimationConfig",menuName = "Config/EnemyAnimation",order = 50)]
public class EnemyAnimationConfig : ScriptableObject
{
    [SerializeField] private string _idelAnimationName = "Ided";
    [SerializeField] private string _runAnimationName = "Run";

    public int IdelAnimationHash => Animator.StringToHash(_idelAnimationName);

    public int RunAnimationHash => Animator.StringToHash(_runAnimationName);
}
