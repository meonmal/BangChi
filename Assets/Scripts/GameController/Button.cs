using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : GameManager
{
    public float minClickTime = 0.0f;
    public bool isClick;
    public float clickTime;


    public void ButtonDown()
    {
        isClick = true;
    }


    public void ButtonUp()
    {
        isClick = false;
        if(clickTime > minClickTime)
        {
            Butten_Level_Up_Damage();
        }
    }
    public void Update()
    {
        if(isClick)
        {
            clickTime = Time.deltaTime;
        }
        else
        {
            clickTime = 0.0f;
        }
    }
}
