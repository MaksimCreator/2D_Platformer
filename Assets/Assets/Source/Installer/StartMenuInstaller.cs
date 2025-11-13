using UnityEngine;
using Zenject;

public class StartMenuInstaller : MonoInstaller
{
    [SerializeField] private LevelsPanelView _levelPanel;
    [SerializeField] private ButtonAnimationConfig _buttonAnimationConfig;
    [SerializeField] private UnlockedLevelConfig _unlockedLevelConfig;

    public override void InstallBindings()
    {
        RegistarySO();
        RegistaryLoader();
        RegistaryAnimation();
        RegistaryPresenter();
    }

    private void RegistarySO()
    {
        Container.Bind<ButtonAnimationConfig>()
            .FromInstance(_buttonAnimationConfig)
            .AsSingle();

        Container.Bind<UnlockedLevelConfig>()
            .FromInstance(_unlockedLevelConfig)
            .AsSingle();
    }

    private void RegistaryPresenter()
    {
        Container.Bind<IStartPanelPresenter>()
            .To<StartPanelPresenter>()
            .FromNew()
            .AsSingle();

        Container.Bind<LevelsPanelPresenter>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryAnimation() 
    {
        Container.Bind<IButtonAnimation>()
            .To<ButtonAnimation>()
            .FromNew()
            .AsCached();
    }

    private void RegistaryLoader() 
    {
        Container.Bind<GameDataLoader>()
            .FromNew()
            .AsSingle();

        Container.Bind<UnlockedLevelLoader>()
            .FromNew()
            .AsSingle();
    }
}
