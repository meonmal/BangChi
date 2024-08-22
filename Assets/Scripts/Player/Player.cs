using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public static Player Instance;
    public Character target;
    public GameObject monster;
    public int Lv_Hp = 200;
    public int Lv_Gold = 200;
    public Animator animator;


    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }


    /// <summary>
    /// 쿨타임이 없으면 굉장히 빠른 속도로 공격을 하기에 넣어주는 변수(변동 가능성 있음)
    /// </summary>
    float Attack_CoolTime = 0.0f;   

    private void Start()
    {
        Init(10, 10);   // hp = 10, damage = 10
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        monster = GameObject.FindGameObjectWithTag("monster");
    }



    private void Update()
    {
        if (monster != null)
        {
            if (monster.GetComponent<MonsterBase>().Hp > 0)
            {
                animator.SetInteger("AniState", 1);

                if (Attack_CoolTime < Attack_Speed)  // 어택 쿨타임이 어택 스피드보다 작을 때 실행
                {
                    Attack_CoolTime += Time.deltaTime;  // 어택 쿨타임은 Time.deltaTime 만큼 증가하고 
                }
                else        // 결국은 어택 쿨타임이 어택 스피드와 같아지게 되고 그 때 실행(공격이 실행 됨)
                {
                    Hit_Damage(target, Damage); // Charater의 Hit_Damage함수 실행(타겟은 유니티에서 설정, 플레이어의 데미지(지금은 10)을 실행
                    Attack_CoolTime = 0f;   // 공격이 끝나면 어택 쿨타임은 다시 0으로 초기화 됨
                }
            }
        }

        else if (monster == null)
        {
            animator.SetInteger("AniState", 2);
        }
    }

    

    public void Spawn()
    {
        Hp = MaxHp;
        State = Character_State.Idle;
    }

    public void Level_Up(string status)
    {
        if (status == "pow")
        {
            Damage += Damage * GameManager.Instance.m_Player_Value.Level_Damage;
        }
    }

    public void Attack(BigInteger damage)
    {
        Get_Damage(damage);
    }

    public void Attack_Monster()
    {
        Attack(Damage);
    }
}
