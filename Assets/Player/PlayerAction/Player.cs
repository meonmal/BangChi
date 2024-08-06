using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    private const int MinPower = 1;
    private const int MaxPower = 10;

    public int power = 5;

    Rigidbody2D rigid;

    AnimationEvent trigger;

    public string Player_Run;
    public string Player_Idle;
    public bool Player_Attack;

    string nowMode = "";
    

    public void Awake()
    {
        Player player = GetComponent<Player>();
        player.power = power;
        MonsterBase monster = GetComponent<MonsterBase>();
        power = monster.MaxHP--;

        
        
    }

    public void Start()
    {
        nowMode = Player_Run;
    }

    public void Update()
    {
        if(Player_Attack == true)
        {
            
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        AnimationEvent trigger = GetComponent<AnimationEvent>();

    }

    int Power
    {
        get => power;

        set
        {
            if(power != value)
            {
                power = value;
                
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("���� �ε���");
            
        }
    }


}
