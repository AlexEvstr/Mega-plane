using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneObjectDetector : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;
    private void Start()
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
            Debug.Log("enemy");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Magnet"))
        {
            Debug.Log("magnet");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            Debug.Log("shield");
            Destroy(collision.gameObject);
        }
    }
}
