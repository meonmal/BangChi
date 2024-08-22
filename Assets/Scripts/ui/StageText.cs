using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageText : MonoBehaviour
{
    public GameObject monster;

    public float stageUpSpeed = 100.0f;

    TextMeshProUGUI stage;

    public int StageIndex = 1;

    float displayStage = 0.0f;

    public void Awake()
    {
        Transform child = transform.GetChild(1);
        
        stage = child.GetComponent<TextMeshProUGUI>();
    }

    public int Stage
    {
        get => StageIndex;
        set
        {
            StageIndex = value;
        }
    }

    void Update()
    {
        if(displayStage < StageIndex)
        { 
            stage.text = $"{displayStage:f0}";
        }
    }

    public void OnInitialized()
    {
        Stage = 0;
        
        stage.text = $"0" + StageIndex;
    }


    public void AddStage(int point)
    {
        monster.GetComponent<MonsterBase>().point = point;
        
        point = StageIndex;
        
        Stage += point;
    }

}
