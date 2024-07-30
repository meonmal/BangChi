using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool attack = false;

    public int AttackDamaged = 1;

    public int AttckSpeed;

    Animator animator;

    Transform Attacktransform;

    IEnumerator AttackCoroutine;

    void Attack()
    {
        attack = true;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    void SetAction()
    {

    }

    public int DMG
    {
        get => AttackDamaged;
        set
        {
            AttackDamaged = value;
        }
    }

}
