using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Falling2 : MonoBehaviour
{
    public GameObject fallingObject;
    public float spawnInterval;
    public float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FallingObject", 1.0f ,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FallingObject()
    {
        spawnRange = gameObject.transform.localScale.x;
        float RandomX = UnityEngine.Random.Range(-spawnRange/2, spawnRange/2);
        Vector2 randomPosition = new Vector2(RandomX, gameObject.transform.position.y);

        Instantiate(fallingObject, randomPosition, quaternion.identity);
    }
}
