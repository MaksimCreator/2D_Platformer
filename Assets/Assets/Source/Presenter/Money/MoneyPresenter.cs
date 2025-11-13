public class MoneyPresenter : IMoneyPresenter
{
    private readonly ICharacterMoneyPresenter _character;
    private readonly IMoneyViewFactory _factory;
    private readonly Money _money;

    public MoneyPresenter(ICharacterMoneyPresenter character, IMoneyViewFactory factory,Money money) 
    {
        _money = money;
        _factory = factory;
        _character = character;
    }

    public void HitMoney() 
    {
        _character.AddCoins(_money.CountMoney);
        _factory.Destroy(_money);
    }
}
