using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 

    public float Power = 10.0f;

    Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        Player myPlayer = new Player();
        myPlayer.Attack();
    }

    public void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("HeroKnight_Attack1") == true)
        {
            float animatorTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if(animatorTime == 0)
            {

            }
            if (animatorTime > 0 && animatorTime < 1.0f)
            {

            }
            else if(animatorTime >= 1.0f)
            {

            }
        }
            
    }


    public void Attack()
    {
        Debug.Log(this.Power + "데미지를 입혔습니다.");
    }

    
}
