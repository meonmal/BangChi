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

    public void Awake()
    {
        Player player = GetComponent<Player>();
        
        MonsterBase monster = GetComponent<MonsterBase>();
        
    }


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
        moveSpeed = 0;
    }


    protected virtual void OnMoveUpdate(float deltaTime)
    {
        transform.Translate(moveSpeed * Vector3.left * Time.deltaTime);
    }





    public void OnHit()
    {
        Debug.Log("적이 맞았습니다");
    }

    public void OnDie()
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
