using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Rigidbody2D rb;
    public float forceMin;
    public float forceMax;
    public float timeToDestroy = 5f;

    void Start()
    {
        rb.AddForce(new Vector2(Random.Range(forceMin, forceMax), Random.Range(forceMin, forceMax)));
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
