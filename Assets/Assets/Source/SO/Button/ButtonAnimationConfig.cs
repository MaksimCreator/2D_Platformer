using UnityEngine;

[CreateAssetMenu(fileName = "ButtonConfig",menuName = "Config/Button",order = 50)]
public class ButtonAnimationConfig : ScriptableObject 
{
    [SerializeField] private float _scaleFactor = 1.35f;
    [SerializeField] private float _durationIncrease = 0.35f;
    [SerializeField] private float _durationDecrease = 0.35f;

    public float ScaleFactor => _scaleFactor;
    
    public float DurationIncrease => _durationIncrease;

    public float DurationDecrease => _durationDecrease;
}