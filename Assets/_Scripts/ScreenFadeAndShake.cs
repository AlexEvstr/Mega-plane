using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFadeAndShake : MonoBehaviour
{
    [SerializeField] private Image whiteScreenImage;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject _losePanel;
    private float fadeDuration = 1.0f;
    private float shakeDuration = 1.0f;
    private float shakeMagnitude = 0.5f;

    void Start()
    {
        whiteScreenImage.gameObject.SetActive(false);
    }

    public void TriggerFadeAndShake()
    {
        StartCoroutine(FadeAndShake());
    }

    private IEnumerator FadeAndShake()
    {
        whiteScreenImage.gameObject.SetActive(true);
        whiteScreenImage.color = new Color(1, 1, 1, 1);

        float elapsed = 0.0f;
        Vector3 originalPosition = mainCamera.transform.position;

        while (elapsed < fadeDuration || elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;

            if (elapsed < fadeDuration)
            {
                float alpha = Mathf.Lerp(1, 0, elapsed / fadeDuration);
                whiteScreenImage.color = new Color(1, 1, 1, alpha);
            }
            else
            {
                whiteScreenImage.color = new Color(1, 1, 1, 0);
                whiteScreenImage.gameObject.SetActive(false);
            }

            if (elapsed < shakeDuration)
            {
                float offsetX = Random.Range(-1f, 1f) * shakeMagnitude;
                float offsetY = Random.Range(-1f, 1f) * shakeMagnitude;
                mainCamera.transform.position = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);
            }
            else
            {
                mainCamera.transform.position = originalPosition;
            }

            yield return null;
        }

        mainCamera.transform.position = originalPosition;
        _losePanel.SetActive(true);
    }
}
