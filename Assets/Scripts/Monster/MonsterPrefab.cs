using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPrefab : MonoBehaviour
{
    MonsterBase monster;
    public GameObject prefab;
    public GameObject MonstersPrefab;

    public void Awake()
    {
        monster = GetComponent<MonsterBase>();
    }

    public void Update()
    {
        
    }

}
