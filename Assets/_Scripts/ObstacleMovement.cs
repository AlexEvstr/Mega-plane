using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 3);
    }
}
