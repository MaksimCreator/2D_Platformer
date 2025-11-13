using UnityEngine;

public class MoneyView : MonoBehaviour
{
    private IMoneyPresenter _moneyPresenter;

    private bool _isInit;

    public void Construct(IMoneyPresenter moneyPresenter)
    {
        if (_isInit)
            return;

        _isInit = true;
        _moneyPresenter = moneyPresenter;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CharacterView characterView))
            _moneyPresenter.HitMoney();
    }
}