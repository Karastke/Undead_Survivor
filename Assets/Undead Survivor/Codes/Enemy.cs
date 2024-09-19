using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;
    SpriteRenderer sprite;
    Animator anim;

    Rigidbody2D rigid;

    bool isLive;

    void Awake()
    {
        anim = GetComponent<Animator>();
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
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Bullet"))
        {
            return;
        }
        health -= other.GetComponent<Bullet>().damage;

        if (health > 0)
        {
            //피격
        }
        else
        {
            //죽음
            Dead();
        }

        
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
