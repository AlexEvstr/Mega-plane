using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBonus : MonoBehaviour
{
    [SerializeField] private GameObject _magnet;
    private float _magnetForce = 10.0f;

    public void ActivateMagnet()
    {
        StartCoroutine(CoinsMovement(9.5f));
        StartCoroutine(MagnetBehavior());
    }

    private IEnumerator MagnetBehavior()
    {
        _magnet.SetActive(true);
        yield return new WaitForSeconds(8.0f);
        _magnet.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        _magnet.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        _magnet.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        _magnet.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        _magnet.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        _magnet.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        _magnet.SetActive(false);
    }

    private IEnumerator CoinsMovement(float magnetDuration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < magnetDuration)
        {
            elapsedTime += Time.deltaTime;

            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
            foreach (GameObject coin in coins)
            {
                coin.GetComponent<CoinMovement>().enabled = false;
                Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 direction = (_magnet.transform.position - coin.transform.position).normalized;
                    float step = _magnetForce * Time.deltaTime;
                    coin.transform.position = Vector2.MoveTowards(coin.transform.position, _magnet.transform.position, step);
                }
            }

            yield return null;
        }
        _magnet.SetActive(false);
        GameObject[] coinss = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coinss)
        {
            coin.GetComponent<CoinMovement>().enabled = true;
        }
    }
}
