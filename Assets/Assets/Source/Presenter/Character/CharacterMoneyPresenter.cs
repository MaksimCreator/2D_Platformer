using Zenject;

public class CharacterMoneyPresenter : ICharacterMoneyPresenter 
{
    private readonly Character _character;

    [Inject]
    public CharacterMoneyPresenter(Character character) 
    {
        _character = character;
    }

    public void AddCoins(int money)
    {
        _character.AddMoney(money);
    }
}