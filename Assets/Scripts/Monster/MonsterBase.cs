using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Rigidbody2D))]
public class MonsterBase : MonoBehaviour
{
    public int Current_HP;

    public float lifeTime = 100000000.0f;

    public int hp = 20;

    Rigidbody2D rigid;


    public float moveSpeed = 5.0f;

    public GameObject Player;

    MonsterBase monster;

    public void Awake()
    {
        Player player = GetComponent<Player>();
        
        MonsterBase monster = GetComponent<MonsterBase>();

        transform.position = new Vector3(30, -4, 0);
        
    }

    

    private void Update()
    {
        OnMoveUpdate();

        if(hp <= 1)
        {
            Player.GetComponent<Player>().Monster = null;

            OnDie();
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Player = GameObject.FindGameObjectWithTag("player");
    }


    public void OnMoveUpdate()
    {
        transform.Translate(moveSpeed * Vector3.left * Time.deltaTime);
    }

    public void OnDie()
    {
        this.gameObject.SetActive(false);



        OnRegen();


        Debug.Log("Á×À½");
    }

    private void OnRegen()
    {
       this.gameObject.SetActive(true);

        Player.GetComponent<Player>().Monster = this.gameObject;

        transform.position = new Vector3(30, -4, 0);

        

        Debug.Log("»ìÀ½");

    }

}
