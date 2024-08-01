using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UIElements;

public class Monster1 : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float stopX =  -8.0f;
    public float spawnY = -0.4f;

    public Transform Player;

    

    public Transform targetPoint;

    public int hp = 100;

    bool isAlive = true;

    Vector3 start = new Vector3(0, 0, 0);
    Vector3 destination = new Vector3(-8.0f, 0, 0);

    public void Awake()
    {
        
    }


    private void Start()
    {
        spawnY = transform.position.y;
        stopX = transform.position.x;
        
    }



    private void Update()
    {

        // Vector3 dir = player.transform.position - transform.position;
        transform.Translate(Time.deltaTime * moveSpeed * Vector3.left);

        //Vector3 direction = Player.position - transform.position;
        //transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

        //if (Vector3.Distance(transform.position, Player.position) < 1.0f)
        //{

        //}

        // transform.position = Vector3.MoveTowards(start, destination, 0);
        //Vector3 speed = Vector3.zero;
        //transform.position = 

        if (this.transform.position.x == Player.transform.position.x) 
        {
            PrintAfterWait();
        }
        
    }

    IEnumerator PrintAfterWait()
    {
        yield return new WaitForSeconds(moveSpeed);
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

    public void Damage(int damage)
    {
        this.hp -= damage;
        Debug.Log(damage + "데미지를 입었습니다.");
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
