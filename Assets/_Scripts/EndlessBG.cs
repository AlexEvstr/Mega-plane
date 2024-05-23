using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBG : MonoBehaviour
{
    private float _speed = 2f;
    private Vector2 _zeroPosition;
    private float _middleOfBackground;

    private void Start()
    {
        _zeroPosition = transform.position;
        _middleOfBackground = GetComponent<BoxCollider2D>().size.y / 2;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);
        if (transform.position.y < (_zeroPosition.y - _middleOfBackground))
            transform.position = _zeroPosition;
    }
}
