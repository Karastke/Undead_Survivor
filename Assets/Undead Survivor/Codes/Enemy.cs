using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D target;
    public float stopDistance = 1.5f;
    SpriteRenderer sprite;

    Rigidbody2D rigid;

    bool isLive = true;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isLive)
        {
            Chase();
        }
        else
        {
            return;
        }

    }

    void LateUpdate()
    {
        if (!isLive)
            return;

        sprite.flipX = target.position.x < rigid.position.x;
    }

    void Chase()
    {

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
                rigid.MovePosition(rigid.position + nextVec);
            rigid.velocity = Vector2.zero;


                //1. 적과의 거리를 계산하기
        // float distance = Vector2.Distance(rigid.position, player.transform.position);

        // // 거리가 stopDistance보다 크면 플레이어 추적
        // if (distance > stopDistance)
        // {
        //     //플레이어 방향으로의 벡터 계산하기
        //     Vector2 direction = (player.transform.position - transform.position).normalized;

            // 플레이어 방향으로 적 이동

            

        }
    void OnEnable()
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
    }
}
