using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int Damage;

    public float DamageRate;

    private List<Attack> thingstoDamage = new List<Attack>();

    Rigidbody2D rigidbody2d;

    private void Start()
    {
        InvokeRepeating("DealDamage", 0, DamageRate);
    }

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        OnAttack();
    }

    public void OnAttack()
    {
        
    }

}
