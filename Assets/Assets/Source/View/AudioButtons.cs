using UnityEngine;

public class AudioButtons : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    [SerializeField] private AudioClip _enterButton;

    private void Awake()
    => _source.playOnAwake = false;

    public void PlayButtonAudio() 
    {
        _source.clip = _enterButton;
        _source.Play();
    }

    public void StopAudio()
    => _source.Stop();
}