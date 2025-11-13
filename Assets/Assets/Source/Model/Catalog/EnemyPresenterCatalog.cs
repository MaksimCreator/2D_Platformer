using System.Collections.Generic;

public class EnemyPresenterCatalog : IUpdateble, IControl
{
    private readonly HashSet<IEnemyPresenter> _enemyPresenters = new();

    private bool _isEnable = false;

    public void Add(IEnemyPresenter presenter)
    { 
        _enemyPresenters.Add(presenter);
        
        if(_isEnable)
            presenter.Enable();
    }

    public void Remove(IEnemyPresenter presenter)
    { 
        _enemyPresenters.Remove(presenter);
        presenter.Disable();
    }

    public void Disable()
    {
        if (_isEnable == false)
            return;

        _isEnable = false;

        foreach (IEnemyPresenter decision in _enemyPresenters)
            decision.Disable();
    }

    public void Enable()
    {
        if (_isEnable)
            return;

        _isEnable = true;

        foreach (IEnemyPresenter decision in _enemyPresenters)
            decision.Enable();
    }

    public void Update(float delta)
    {
        if (_isEnable == false)
            return;

        foreach (IEnemyPresenter decision in _enemyPresenters)
            decision.Update(delta);
    }
}
