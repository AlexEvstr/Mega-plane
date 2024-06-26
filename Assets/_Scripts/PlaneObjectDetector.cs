using UnityEngine;

public class PlaneObjectDetector : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private ScreenFadeAndShake _screenFadeAndShake;
    [SerializeField] private ShieldBonus _shieldBonus;
    [SerializeField] private MagnetBonus _magnetBonus;

    [SerializeField] private GameAudioController _gameAudioController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            _coinsCounter.IncreaseCoinsCount();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            _screenFadeAndShake.TriggerFadeAndShake();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Magnet"))
        {
            _gameAudioController.BonusSound();
            Destroy(collision.gameObject);
            _magnetBonus.ActivateMagnet();
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            _gameAudioController.BonusSound();
            Destroy(collision.gameObject);
            _shieldBonus.ActivateShield();
        }
    }
}