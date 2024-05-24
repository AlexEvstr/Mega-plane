using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;
    [SerializeField] private float _yPositionToShoot;

    private bool _canShoot;

    private void Start()
    {
        _canShoot = true;
    }
    private void FixedUpdate()
    {
        if (_canShoot)
        {
            if (transform.position.y < _yPositionToShoot)
            {
                GameObject rocket = Instantiate(_rocket, transform);
                rocket.transform.position = new Vector2(transform.position.x,
                                                        transform.position.y - 0.2f);
                _canShoot = false;
            }
        }
    }
}
