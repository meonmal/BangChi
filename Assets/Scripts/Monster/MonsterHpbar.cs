using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Character;
using Vector3 = UnityEngine.Vector3;

public class MonsterHpbar : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI monsterText;

    [SerializeField]
    Slider monsterslider;

    public BigInteger hp;
    public BigInteger maxhp;
    public GameObject monster;
    public Transform Monster;

    public void Start()
    {
        monster = GameObject.FindGameObjectWithTag("monster");
        maxhp = monster.gameObject.GetComponent<MonsterBase>().MaxHp;
        hp = monster.gameObject.GetComponent<MonsterBase>().Hp;
        monsterslider.value = (float) hp / (float) maxhp;
        monsterText.text = (hp + "/" + maxhp);

    }

    public void Update()
    {
        Hpbar();
        transform.position = Monster.position + new Vector3(0, 3, 0);
    }


    public void Hpbar()
    {
        monsterslider.value = (float)hp / (float)maxhp;
        monsterText.text = (hp + "/" + maxhp);
    }


}
