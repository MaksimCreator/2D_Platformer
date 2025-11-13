using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : Panel,IDeathPanel
{
    [SerializeField] private Button _reset;

    private IDeathPanelPresenter _presenter;

    public void BindPresenter(IDeathPanelPresenter deathPanelPresenter)
    => _presenter = deathPanelPresenter;

    private void OnEnable()
    {
        _reset.onClick.AddListener(onReset);
    }

    private void OnDisable()
    {
        _reset.onClick.RemoveAllListeners();
    }

    private void onReset()
    {
        _presenter.Reset();
        Hide();
    }
}
