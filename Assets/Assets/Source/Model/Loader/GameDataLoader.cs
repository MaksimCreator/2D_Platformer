public class GameDataLoader : Loader<GameDataStorage>
{
    private readonly UnlockedLevelConfig _config;

    public GameDataLoader(UnlockedLevelConfig config,IGameRepository gameRepository) : base(gameRepository)
    {
        _config = config;
    }

    protected override GameDataStorage GetData()
    => new GameDataStorage(_config);
}