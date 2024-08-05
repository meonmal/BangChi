using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    protected const float SpawnX = 10;
    protected const float SpawnY = 1;



    private void Start()
    {
        
    }



    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(SpawnX);
    }

    protected virtual void Spawn()
    {

    }
}
