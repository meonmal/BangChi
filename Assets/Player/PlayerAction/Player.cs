using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    private const int MinPower = 1;
    private const int MaxPower = 10;

    int power = 1;

    Rigidbody2D rigid;

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
            Debug.Log("Àû°ú ºÎµúÈû");
        }
    }


}
