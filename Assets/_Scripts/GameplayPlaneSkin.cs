using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayPlaneSkin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _plane;
    [SerializeField] private GameObject _planeObject;
    [SerializeField] private Sprite[] _planeSprites;

    private void OnEnable()
    {
        int index = int.Parse(PlayerPrefs.GetString("Plane", "0"));
        _plane.sprite = _planeSprites[index];
        _planeObject.AddComponent<PolygonCollider2D>();
        _planeObject.GetComponent<PolygonCollider2D>().isTrigger = true;
    }
}
