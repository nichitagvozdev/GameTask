using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    private float _randomX; // Change to _randomX
    Vector2 whereToSpawn;
    public float spawnDelay;
    float nextSpawn = 0.0f;

    void Start()
    {
        // Initialization code, if needed.
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnDelay;
            _randomX = Random.Range(-8, 8);
            whereToSpawn = new Vector2(_randomX, transform.position.y);
            GameObject Enemy = Instantiate(obj, whereToSpawn, Quaternion.identity);
            Destroy(Enemy, 3f);
        }
    }
}