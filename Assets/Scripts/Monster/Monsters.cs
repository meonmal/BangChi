using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    MonsterBase monster;

    Transform monster1;
    Transform monster2;
    Transform monster3;
    Transform monster4;

    private void Awake()
    {
        monster = GetComponent<MonsterBase>();
    }

    private void Start()
    {
        monster1 = transform.GetChild(0);
        monster2 = transform.GetChild(1);
        monster3 = transform.GetChild(2);
        monster4 = transform.GetChild(3);
    }

    private void Update()
    {
        if(monster == null)
        {
            monster = GetComponent<MonsterBase>();
            monster.gameObject.SetActive(true);

            
        }
    }



}
