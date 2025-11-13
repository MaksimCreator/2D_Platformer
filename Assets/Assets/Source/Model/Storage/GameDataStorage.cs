using System;

public class GameDataStorage : Storage
{
    private const int INDEX_FIRST_LEVEL = 1;

    private readonly int _maxLevel;

    public GameDataStorage(UnlockedLevelConfig config) : base(INDEX_FIRST_LEVEL)
    {
        _maxLevel = config.MaxLevel;
    }

    public void SetIndexLevel(int level) 
    {
        if (level > _maxLevel || level < 0)
            throw new InvalidOperationException();

        Reset();
        AddValue(level);
    }
}
