using UnityEngine;
using Zenject;

public class DeathZone : MonoBehaviour
{
    private ICharacterHealthPresenter _characterHealthPresenter;

    [Inject]
    private void Construct(ICharacterHealthPresenter characterHealthPresenter) 
    {
        _characterHealthPresenter = characterHealthPresenter;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CharacterView view))
            _characterHealthPresenter.Death();
    }
}
