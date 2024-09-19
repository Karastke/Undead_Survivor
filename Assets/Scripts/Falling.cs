using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float _range = 0;
    public float fallingInterval = 1.0f;
    public GameObject fallingObject;


    
    void Start()
    {
        InvokeRepeating("FallingObject", 1.0f, fallingInterval);
    }



    void Update()
    {
        
    }

    void FallingObject()
    {
        _range = gameObject.transform.localScale.x;
        float randomRange = UnityEngine.Random.Range(-_range/2, _range/2);
        Vector2 spawnPosition = new Vector2(randomRange, gameObject.transform.position.y);
        Instantiate(fallingObject, spawnPosition, quaternion.identity);
    }
}
