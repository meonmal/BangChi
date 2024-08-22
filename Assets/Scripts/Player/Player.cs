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
    /// ��Ÿ���� ������ ������ ���� �ӵ��� ������ �ϱ⿡ �־��ִ� ����(���� ���ɼ� ����)
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

                if (Attack_CoolTime < Attack_Speed)  // ���� ��Ÿ���� ���� ���ǵ庸�� ���� �� ����
                {
                    Attack_CoolTime += Time.deltaTime;  // ���� ��Ÿ���� Time.deltaTime ��ŭ �����ϰ� 
                }
                else        // �ᱹ�� ���� ��Ÿ���� ���� ���ǵ�� �������� �ǰ� �� �� ����(������ ���� ��)
                {
                    Hit_Damage(target, Damage); // Charater�� Hit_Damage�Լ� ����(Ÿ���� ����Ƽ���� ����, �÷��̾��� ������(������ 10)�� ����
                    Attack_CoolTime = 0f;   // ������ ������ ���� ��Ÿ���� �ٽ� 0���� �ʱ�ȭ ��
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
