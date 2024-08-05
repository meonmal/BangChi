using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class MonsterBase : MonoBehaviour
{

    public float lifeTime = 100000000.0f;

    int hp = 1;

    public int MaxHP = 1;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HP--;
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
        if (IsAlive)
        {
            IsAlive = false;

            Debug.Log("몬스터사망");

            DisableTimer();
        }
    }

    protected void DisableTimer(float time = 0.0f)
    {
        StartCoroutine(LifeOver(time));
    }

    IEnumerator LifeOver(float time = 0.0f)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }



}
