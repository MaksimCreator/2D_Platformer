using UnityEngine;

public interface IEnemyViewFactory 
{
    void Creat(Vector3 position);
    void Destroy(Enemy enemy);
}