using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Character : MonoBehaviour
{
    public BigInteger Hp;
    
    public BigInteger MaxHp;
    
    public BigInteger Damage;
    
    public float Attack_Speed;
    
    public Character_State State;
    
    public BigInteger Gold;

    public enum Character_State
    {
        Idle,
        Die,
    }

    public void Init(BigInteger hp, BigInteger damage)
    {
        MaxHp = hp;
        
        Hp = MaxHp;
        
        Damage = damage;
        
        Attack_Speed = 1.0f;
        
        Gold = 10;
        
        State = Character_State.Idle;
    }

    public void Get_Hp(BigInteger hp)
    {
        if (State == Character_State.Die)
        {
            return;
        }

        Hp += hp;
        if(hp > MaxHp)
        {
            Hp = MaxHp;
        }
    }

    public void Get_Damage(BigInteger damage)
    {
        if(State == Character_State.Die)
        {
            return;
        }

        Hp -= damage;
        if(Hp <= 0)
        {
            OnDie();
        }
    }

    public void Hit_Damage(Character target, BigInteger damage)
    {
        target.Get_Damage(damage);
        
        Debug.Log("target State : " + target.State + "HP : " + target.Hp + " / "+ damage);
        
        GameManager.Instance.Set_Text(damage.ToString(), target.transform.position);
    }

    public virtual void OnDie()
    {
        Debug.Log("Á×À½");
        
        State = Character_State.Die;
    }
}
