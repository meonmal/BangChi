using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public class Player_Value
    {
        public BigInteger Gold;
        public BigInteger Level_Hp;
        public BigInteger Level_Damage;

        public void Get_Gold(BigInteger vaule, UnityEngine.Vector3 pos)
        {
            Gold += vaule;
            GameManager.Instance.Text_Gold.text = "Gold : " + Gold;
            GameManager.Instance.Set_Text(vaule.ToString(), pos);
        }

        public void Get_Level_Hp()
        {
            Level_Hp += 1;
            GameManager.Instance.Text_Level_Hp.text = "Level HP : " + Level_Hp;
        }

        public void Get_Level_Damage()
        {
            Level_Damage += 1;
            GameManager.Instance.Text_Level_Damage.text = "Level Damage : " + Level_Damage;
        }
    }

    public static GameManager Instance;
    public Player_Value m_Player_Value;
    public TextMeshProUGUI Text_Gold;
    public TextMeshProUGUI Text_Level_Hp;
    public TextMeshProUGUI Text_Level_Damage;
    public TextMeshProUGUI Text_Damage;
    public List<TextMeshProUGUI> Text_List;


    private void Awake()
    {
        Instance = this;
    }


    public void Start()
    {
        m_Player_Value = new Player_Value();
        GameManager.Instance.Text_Gold.text = "Gold : " + m_Player_Value.Gold;
        GameManager.Instance.Text_Level_Hp.text = "Level Hp : " + m_Player_Value.Level_Hp;
        GameManager.Instance.Text_Level_Damage.text = "Level Damage : " + m_Player_Value.Level_Damage;
    }

    private void Update()
    {
        
    }



    public void Set_Text(string text, UnityEngine.Vector3 pos)
    {
        bool set = false;
        foreach (TextMeshProUGUI t in Text_List)
        {
            if (!t.gameObject.activeSelf)
            {
                t.text = text;
                t.transform.position = Camera.main.WorldToScreenPoint(pos);
                t.gameObject.SetActive(true);
                set = true;
                break;
            }
            
        }

        if (!set)
        {
            TextMeshProUGUI t = Instantiate(Text_Damage, Camera.main.WorldToScreenPoint(pos), UnityEngine.Quaternion.identity).GetComponent<TextMeshProUGUI>();
            t.transform.SetParent(Text_Damage.transform.parent);
            t.text = text;
            Text_List.Add(t);
        }
    }

}
