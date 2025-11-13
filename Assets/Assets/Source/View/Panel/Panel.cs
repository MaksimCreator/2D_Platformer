using UnityEngine;

public abstract class Panel : MonoBehaviour 
{
    [SerializeField] private GameObject _panel;

    public void Show()
    => _panel.SetActive(true);

    public void Hide()
    => _panel.SetActive(false);
}