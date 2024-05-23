using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 2);
    }
}
