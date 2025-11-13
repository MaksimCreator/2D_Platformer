using Cysharp.Threading.Tasks;
using UnityEngine;

public interface ICharacterAnimation 
{
    CharacterAnimation BindCahracterData(SpriteRenderer spriteRenderer, Animator animator);
    void Idel();
    void Run();
    void Jump();

    UniTask TakeDamage();
}
