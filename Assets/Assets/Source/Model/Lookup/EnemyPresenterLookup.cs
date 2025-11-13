using System.Collections.Generic;

public class EnemyPresenterLookup
{
    private readonly Dictionary<IEnemyView, IEnemyPresenter> _enemyPresenters = new();

    public void Registary(IEnemyView view, IEnemyPresenter presenter)
    => _enemyPresenters.Add(view, presenter);

    public void Remove(IEnemyView view)
    => _enemyPresenters.Remove(view);

    public IEnemyPresenter GetPresenter(IEnemyView view)
    => _enemyPresenters[view];
}