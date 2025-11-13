using System.Collections.Generic;
using System.Linq;

public class MoneyCatalog
{
    private readonly HashSet<Money> _moneys = new();

    public IReadOnlyList<Money> Moneys => _moneys.ToList();

    public void Remove(Money money)
    => _moneys.Remove(money);

    public void Add(Money money)
    => _moneys.Add(money);
}