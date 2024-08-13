using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject Monster;

    public void Awake()
    {
        MonsterBase monster = GetComponent<MonsterBase>();
    }

    public void Start()
    {

    }

    private void Update()
    {
        if(Monster == null)
        {
            Spwan();
        }
    }

    public void Spwan()
    {
        

        Instantiate(Monster);

    }
}
