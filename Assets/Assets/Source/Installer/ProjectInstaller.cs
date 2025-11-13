using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        RegistaryLoader();
        RegistarySaveLoader();
        RegistaryGameRepository();
    }

    private void RegistaryLoader() 
    {
        Container.Bind<MoneyLoader>()
            .FromNew()
            .AsSingle();
    }

    private void RegistarySaveLoader()
    {
        Container.Bind<ISaveLoaderGame>()
            .To<SaveLoaderGame>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryGameRepository()
    {
        Container.Bind<IGameRepository>()
                .To<GameRepository>()
                .FromNew()
                .AsSingle();
    }

}