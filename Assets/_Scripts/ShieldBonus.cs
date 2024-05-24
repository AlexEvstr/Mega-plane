using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonus : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private GameObject _plane;
    private Collider2D _planeCollider;
    private HashSet<Collider2D> ignoredColliders = new HashSet<Collider2D>();

    void Start()
    {
        _planeCollider = _plane.GetComponent<PolygonCollider2D>();
    }

    public void ActivateShield()
    {
        StartCoroutine(DisactivateEnemies(6.6f));
        StartCoroutine(ShieldBehavior());
    }

    private IEnumerator ShieldBehavior()
    {
        _shield.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        _shield.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        _shield.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        _shield.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        _shield.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        _shield.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        _shield.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        _shield.SetActive(false);
    }

   private IEnumerator DisactivateEnemies(float duration)
   {
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            CapsuleCollider2D[] enemyColliders = FindObjectsOfType<CapsuleCollider2D>();

            foreach (CapsuleCollider2D col in enemyColliders)
            {
                if (col.CompareTag("Enemy") && !ignoredColliders.Contains(col))
                {
                    Physics2D.IgnoreCollision(_planeCollider, col, true);
                    ignoredColliders.Add(col);
                }
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        foreach (CapsuleCollider2D col in ignoredColliders)
        {
            if (col != null)
            {
                Physics2D.IgnoreCollision(_planeCollider, col, false);
            }
        }

        ignoredColliders.Clear();

    }
}
