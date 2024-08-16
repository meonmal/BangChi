using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Singlton<Factory>
{
    MonsterPool monster;

    protected override void OnInitialize()
    {
        monster = GetComponentInChildren<MonsterPool>();
        if(monster != null )
            monster.Initialize();
    }

    public MonsterBase GetMonster(Vector3? position, float angle = 0.0f)
    {
        return monster.GetObject(position, new Vector3(30, -4, angle));
    }

}
