using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

[RequireComponent(typeof(Rigidbody2D))]
public class MonsterBase : Character
{
    public Character target;
    public GameObject player;
    public int Lv_Hp = 200;
    public int Lv_Gold = 200;
    public float moveSpeed = 5.0f;
    public float sponX = 30.0f;
    public float sponY = -4.0f;
    


    private void Start()
    {
        Init(10, 0);    // hp = 10, damage = 0
        player = GameObject.FindGameObjectWithTag("player");
    }

    private void Update()
    {
        OnMoveUpdate(Time.deltaTime);

        if (State == Character_State.Die)
        {
            return;
        }
    }

    private void OnMoveUpdate(float deltaTime)
    {
        transform.Translate(deltaTime * moveSpeed * -transform.right, Space.World);
    }

    public override void OnDie()
    {
        base.OnDie();
        Debug.Log("적 사망");
        GameManager.Instance.m_Player_Value.Get_Gold(Gold, this.transform.position);
        this.gameObject.SetActive(false);
        Spawn();
    }

    public void Spawn()
    {
        
        MaxHp += MaxHp * Lv_Hp / 100;
        // MaxHp = 10 + 10 * 200 / 100 가 현재 상태다.
        Gold += Gold * Lv_Gold / 100;
        Hp = MaxHp;
        State = Character_State.Idle;

        transform.position = new Vector2(sponX, sponY);
        this.gameObject.SetActive(true);
    }
}
