using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _tutorialText;
    [SerializeField] private Image _finger;

    private void Start()
    {
        StartCoroutine(DecreaseAlphaChannel());
    }

    private IEnumerator DecreaseAlphaChannel()
    {
        yield return new WaitForSeconds(2f);
        float aImage = 1.0f;
        while (true)
        {
            aImage -= 0.1f;
            _tutorialText.alpha -= 0.1f;
            _finger.color = new Color(1, 1, 1, aImage);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
