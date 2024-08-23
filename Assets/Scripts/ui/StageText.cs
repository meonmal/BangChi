using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageText : MonoBehaviour
{
    public int StageNumber;
    public TextMeshProUGUI Stage;
    public GameObject monster;

    public void StageUp()
    {
        Stage.text = "Stage" + StageNumber;
    }

}
