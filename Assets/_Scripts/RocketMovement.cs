using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;

    private void FixedUpdate()
    {
        transform.Translate(_direction * Time.deltaTime * 2);
    }
}
