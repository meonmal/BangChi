using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Monster1 : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float spawnX = -8.0f;
    public float spawnY = -0.4f;

    public int hp = 10;

    bool isAlive = true;



    public void Awake()
    {
        
    }


    private void Start()
    {
        spawnY = transform.position.y;
    }



    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * Vector3.left);
    }

    public int HP
    {
        get => hp;
        set
        {
            hp = value;
            if (hp < 1)
            {
                OnDie();
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (isAlive)
        {
             HP--;
        }
        
    }

    private void OnEnable()
    {
        
    }


    void OnDie()
    {
        if(isAlive)
        {
            isAlive = false;
            Debug.Log("적이 죽었습니다");
            
        }
    }
}
