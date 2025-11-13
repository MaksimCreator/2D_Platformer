public class UnlockedLevelLoader : Loader<UnlockedLevelStorage>
{
    private readonly UnlockedLevelConfig _config;

    public UnlockedLevelLoader(UnlockedLevelConfig config,IGameRepository gameRepository) : base(gameRepository)
    {
        _config = config;
    }

    protected override UnlockedLevelStorage GetData()
    => new UnlockedLevelStorage(_config);
}