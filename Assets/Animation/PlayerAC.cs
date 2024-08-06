using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAC : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;


    private void Start()
    {
        Application.targetFrameRate = 60;
        this.animator = GetComponent<Animator>();
        this.rigidbody2d = GetComponent<Rigidbody2D>();
        Player player = GetComponent<Player>();
    }

    private void Update()
    {

    }
}
