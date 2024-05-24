using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneObjectDetector : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private ScreenFadeAndShake _screenFadeAndShake;
    [SerializeField] private ShieldBonus _shieldBonus;

    private void Awake()
    {
        gameObject.AddComponent<PolygonCollider2D>();
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
    }

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
            Debug.Log("magnet");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            _shieldBonus.ActivateShield();
        }
    }
}
