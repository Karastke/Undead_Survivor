using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    private Camera _mainCamera;


    void Start()
    {
        _mainCamera = Camera.main;
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0 ;
        }
    }

    // void Update()
    // {
    //     KeepPlayerInBounds();
    // }

    // void KeepPlayerInBounds()
    // {
    //     Vector3 viewPos = _mainCamera.WorldToViewportPoint(transform.position);

    //     viewPos.x = Mathf.Clamp(viewPos.x, 0.0f, 1.0f);
    //     viewPos.y = Mathf.Clamp(viewPos.y, 0.0f, 1.0f);

    //     transform.position = _mainCamera.ViewportToWorldPoint(viewPos);
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BadBall"))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }

}
