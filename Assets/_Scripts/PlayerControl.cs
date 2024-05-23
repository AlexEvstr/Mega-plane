using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool isTouching = false;
    private Vector2 touchStartPosition;
    private Vector2 touchCurrentPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isTouching = true;
                    touchStartPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    if (isTouching)
                    {
                        touchCurrentPosition = touch.position;
                        MovePlayer();
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isTouching = false;
                    break;
            }
        }
    }

    private void MovePlayer()
    {
        Vector2 touchDelta = touchCurrentPosition - touchStartPosition;
        Vector3 newPosition = transform.position;
        newPosition.x += touchDelta.x * Time.deltaTime * 1.0f;
        newPosition.x = Mathf.Clamp(newPosition.x, -8.0f, 8.0f);
        transform.position = newPosition;
        touchStartPosition = touchCurrentPosition;
    }
}
