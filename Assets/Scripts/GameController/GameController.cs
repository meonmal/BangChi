using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Animator PlayerAnimator;

    public void Attack1()
    {
        PlayerAnimator.SetTrigger("Hearo_Knight_Attack1");
    }

    public void PlayerHit()
    {

    }
}
