using UnityEngine;

public interface IMoneyViewFactory 
{
    public void Creat(Vector3 position);
    public void Destroy(Money money);
}
