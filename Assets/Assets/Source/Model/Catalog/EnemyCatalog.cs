using System.Collections.Generic;

public class EnemyCatalog : IControl
{
    private readonly HashSet<Enemy> _enemies = new();

    private bool _isEnable = false;

    public void Add(Enemy enemy)
    {
        _enemies.Add(enemy);

        if (_isEnable)
            enemy.Enable();
    }

    public void Remove(Enemy enemy)
    { 
        enemy.Disable();
        _enemies.Remove(enemy);
    }

    public void Disable()
    {
        if (_isEnable == false)
            return;

        _isEnable = false;

        foreach (var enemy in _enemies)
            enemy.Disable();
    }

    public void Enable()
    {
        if (_isEnable)
            return;

        _isEnable = true;

        foreach (var enemy in _enemies)
            enemy.Enable();
    }
}