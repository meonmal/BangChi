using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class MonsterBase : MonoBehaviour
{

    public float lifeTime = 100000000.0f;

    int hp = 20;

    public int MaxHP = 20;

    Rigidbody2D rigid;


    public float moveSpeed = 5.0f;

    bool IsAlive = true;


    int HP
    {
        get => hp;
        set
        {
            if(hp != value)
            {
                hp = value;
                if (IsAlive)
                {
                    OnHit();
                }
                if (hp < 1)
                {
                    OnDie();
                }
                
                
            }

        }
    }

    private void Update()
    {
        OnMoveUpdate(Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            hp--;
            OnHit();
        }
    }


    protected virtual void OnMoveUpdate(float deltaTime)
    {
        transform.Translate(moveSpeed * Vector3.left * Time.deltaTime);
    }





    private void OnHit()
    {
        Debug.Log("적이 맞았습니다");
    }

    private void OnDie()
    {
        IsAlive = false;

        Debug.Log("몬스터사망");
    }





}
