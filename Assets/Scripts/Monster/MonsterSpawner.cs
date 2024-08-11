using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject WormPrefab;

    public GameObject Monster;

    public void Awake()
    {
        MonsterBase monster = GetComponent<MonsterBase>();
    }

    public void Start()
    {

    }

    public void Spwan()
    {
        if(Monster = null)
        {
            Instantiate(WormPrefab);

        }
    }
}
