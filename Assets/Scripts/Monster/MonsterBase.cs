using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class MonsterBase : Character
{
    public Character target;
    public int Lv_Hp = 200;
    public int Lv_Gold = 200;   

    private void Start()
    {
        Init(10, 0);    // hp = 10, damage = 0
    }

    private void Update()
    {
        if (State == Character_State.Die)
        {
            return;
        }
    }

    public override void OnDie()
    {
        base.OnDie();
        Debug.Log("적 사망");
        GameManager.Instance.m_Player_Value.Get_Gold(Gold, this.transform.position);
        Spawn();
    }

    public void Spawn()
    {
        MaxHp += MaxHp * Lv_Hp / 100;
        // MaxHp = 10 + 10 * 200 / 100 가 현재 상태다.
        Gold += Gold * Lv_Gold / 100;
        Hp = MaxHp;
        State = Character_State.Idle;
    }


}
