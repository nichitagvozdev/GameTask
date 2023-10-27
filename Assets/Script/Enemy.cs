using ClearSky;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Sushi;
    private PlayerController _playerController;

    public void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hp")
        {
            if (_playerController != null)
            {
                _playerController.TakeDamage();
            }
            Destroy(Sushi);
            Debug.Log(_playerController.healthPlayer);
        }
    }
}
