using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public Character target;
    public int Lv_Hp = 200;
    public int Lv_Gold = 200;

    /// <summary>
    /// ��Ÿ���� ������ ������ ���� �ӵ��� ������ �ϱ⿡ �־��ִ� ����(���� ���ɼ� ����)
    /// </summary>
    float Attack_CoolTime = 0.0f;   

    private void Start()
    {
        Init(10, 10);   // hp = 10, damage = 10
    }



    private void Update()
    {
        if(Attack_CoolTime < Attack_Speed)  // ���� ��Ÿ���� ���� ���ǵ庸�� ���� �� ����
        {
            Attack_CoolTime += Time.deltaTime;  // ���� ��Ÿ���� Time.deltaTime ��ŭ �����ϰ� 
        }
        else        // �ᱹ�� ���� ��Ÿ���� ���� ���ǵ�� �������� �ǰ� �� �� ����(������ ���� ��)
        {
            Hit_Damage(target, Damage); // Charater�� Hit_Damage�Լ� ����(Ÿ���� ����Ƽ���� ����, �÷��̾��� ������(������ 10)�� ����
            Attack_CoolTime = 0f;   // ������ ������ ���� ��Ÿ���� �ٽ� 0���� �ʱ�ȭ ��
        }
    }

    public void Spawn()
    {
        Hp = MaxHp;
        State = Character_State.Idle;
    }
}
