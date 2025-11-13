using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoneyViewFactory : MonoBehaviour, IMoneyViewFactory
{
    [SerializeField] private MoneyView _prefab;

    private readonly Dictionary<Money, MoneyView> _views = new();

    private DiContainer _container;
    private ICharacterMoneyPresenter _characterMoneyPresenter;
    private MoneyCatalog _moneyCatalog;

    [Inject]
    private void Construct(DiContainer container, ICharacterMoneyPresenter character,MoneyCatalog moneyCatalog) 
    {
        _container = container;
        _characterMoneyPresenter = character;
        _moneyCatalog = moneyCatalog;
    }

    public void Creat(Vector3 position)
    { 
        MoneyView view = Instantiate(_prefab, position, Quaternion.identity);
        
        Money money = _container.Resolve<Money>();
        IMoneyPresenter presenter = new MoneyPresenter(_characterMoneyPresenter, this,money);

        _moneyCatalog.Add(money);
        _views.Add(money, view);

        view.Construct(presenter);
    }

    public void Destroy(Money money)
    {
        MoneyView view = _views[money];

        _moneyCatalog.Remove(money);
        _views.Remove(money);

        Destroy(view.gameObject);
    }
}
