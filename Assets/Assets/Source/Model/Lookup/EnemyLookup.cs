using System.Collections.Generic;
using System.Linq;

public class EnemyLookup 
{
    private readonly Dictionary<IEnemyView, Enemy> _enemies = new();

    public IReadOnlyList<Enemy> Enemies => _enemies.Values.ToList();

    public void Registary(IEnemyView view, Enemy enemy)
    => _enemies.Add(view, enemy);

    public void Remove(IEnemyView view)
    => _enemies.Remove(view);

    public Enemy GetEnemy(IEnemyView view)
    => _enemies[view];
}