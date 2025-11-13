using System;

[Serializable]
public abstract class Storage
{
    public event Action<int> onUpdate;

    public int Value { get; private set; }

    public Storage(int startValue = 0)
    {
        Value = startValue;
    }

    protected void AddValue(int value)
    {
        if (value < 0)
            throw new InvalidOperationException();

        Value += value;
        onUpdate?.Invoke(Value);
    }

    protected void Reset()
    => Value = 0;
}
