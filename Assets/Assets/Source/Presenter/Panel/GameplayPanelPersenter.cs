using Zenject;

public class GameplayPanelPersenter : IGameplayPanelPresenter
{
    private readonly Character _character;

    public int Score => _character.Score;

    public int Health => _character.Health;

    public int MaxHealth => _character.MaxHealth;

    [Inject]
    public GameplayPanelPersenter(Character character) 
    {
        _character = character;
    } 
}