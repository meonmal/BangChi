using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageText : MonoBehaviour
{
    public float stageUpSpeed = 100.0f;

    TextMeshProUGUI stage;

    int StageIndex = 0;

    float displayStage = 0.0f;

    public void Awake()
    {
        Transform child = transform.GetChild(1);
        stage = child.GetComponent<TextMeshProUGUI>();
    }

    public int Stage
    {
        get => StageIndex;
        private set
        {
            StageIndex = value;
        }
    }

    public void Update()
    {
        if(displayStage < StageIndex)
        {
            

            stage.text = $"{displayStage: f0}";
        }
    }

    public void OnInitialized()
    {
        Stage = 0;
        stage.text = $"0";
    }


    public void AddStage(int point)
    {
        Stage += point;
    }

}
