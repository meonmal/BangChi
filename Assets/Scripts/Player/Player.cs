using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject Monster;

    public int Damage;      // 플레이어의 공격력

    public Animator Animator;

    public void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Monster = GameObject.FindGameObjectWithTag("monster");
    }

    private void Update()
    {
        if (Monster != null)
        {
            if (Monster.GetComponent<MonsterBase>().hp > 0)
            {
                Animator.SetInteger("AniState", 1);
            }
        }
        else if(Monster == null)
        {
            Animator.SetInteger("AniState", 2);
        }
    }

    public void Attack()
    {
        Monster.GetComponent<MonsterBase>().hp -= Damage;
    }

}
