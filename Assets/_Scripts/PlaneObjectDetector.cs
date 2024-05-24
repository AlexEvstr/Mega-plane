using UnityEngine;

public class PlaneObjectDetector : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private ScreenFadeAndShake _screenFadeAndShake;
    [SerializeField] private ShieldBonus _shieldBonus;
    [SerializeField] private MagnetBonus _magnetBonus;

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
            Destroy(collision.gameObject);
            _magnetBonus.ActivateMagnet();
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            _shieldBonus.ActivateShield();
        }
    }
}