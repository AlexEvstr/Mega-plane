using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioController : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _bonusSound;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private AudioClip _gameoverSound;
    [SerializeField] private AudioClip _planeExplosionSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
    }

    public void BonusSound()
    {
        _audioSource.PlayOneShot(_bonusSound);
    }

    public void CoinSound()
    {
        _audioSource.PlayOneShot(_coinSound);
    }

    public void PlaneExplosionSound()
    {
        _audioSource.PlayOneShot(_planeExplosionSound);
    }

    public void GameOverSound()
    {
        _audioSource.PlayOneShot(_gameoverSound);
    }
}