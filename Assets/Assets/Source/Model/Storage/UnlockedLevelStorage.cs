using System;

public class UnlockedLevelStorage : Storage
{
    private readonly int _increment;
    private readonly int _maxLevel;

    public UnlockedLevelStorage(UnlockedLevelConfig config) : base(config.FirstLevel) 
    {
        _increment = config.Increment;
        _maxLevel = config.MaxLevel;
    }

    public void UnlockedNextLevel() 
    {
        if (CanUnlockedNextLevel() == false)
            throw new InvalidOperationException();

        AddValue(_increment);
    }

    public bool CanUnlockedNextLevel() 
    => Value <= _maxLevel;
}
