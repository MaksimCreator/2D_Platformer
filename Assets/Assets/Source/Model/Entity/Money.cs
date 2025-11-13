using Zenject;

public class Money 
{
    private readonly MoneyConfig _config;

    public int CountMoney => _config.CountAddMoney;

    [Inject]
    public Money(MoneyConfig config)
    { 
        _config = config;
    }
}