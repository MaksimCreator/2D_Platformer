using UnityEngine;
using Zenject;

public class CharacterViewFactory : MonoBehaviour, ICharacterViewFactory
{
    [SerializeField] private CharacterView _sceneCharacterView;

    private Character _character;
    private Transform _characterTransform;

    [Inject]
    private void Construct(Character character)
    {
        _character = character;
        _characterTransform = _sceneCharacterView.transform;
    }

    public void Creat(Vector3 position)
    { 
        _sceneCharacterView.gameObject.SetActive(true);
        _characterTransform.position = position;
        _character.SetPositionX(position.x);
    }

    public void Destroy()
    => _sceneCharacterView.gameObject.SetActive(false);
}