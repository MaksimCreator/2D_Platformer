using System.Collections.Generic;

public class DecisionEnemyCatalog : IUpdateble,IControl
{
    private readonly HashSet<DecisionEnemy> _decisionEnemys = new HashSet<DecisionEnemy>();
    private bool _isEnable = false;

    public void Add(DecisionEnemy decision)
    => _decisionEnemys.Add(decision);

    public void Remove(DecisionEnemy decision)
    => _decisionEnemys.Remove(decision);

    public void StartMove() 
    {
        foreach(var decision in _decisionEnemys)
            decision.StartMove();
    }

    public void Disable()
    => _isEnable = false;

    public void Enable()
    => _isEnable = true;

    public void Update(float delta)
    {
        if (_isEnable == false)
            return;

        foreach (var decision in _decisionEnemys)
            decision.Update(delta);
    }
}
