using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public float spawnInterval = 5f;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 5f, spawnInterval);
    }

    // Update is called once per frame
    private void Spawn() { Instantiate(enemy, transform.position, transform.rotation); }
}
