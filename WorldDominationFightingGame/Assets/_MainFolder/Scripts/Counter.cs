using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TriggerCounter p1Score;
    public TriggerCounter p2Score;
    public TriggerCounter p3Score;
    int s1;
    int s2;
    int s3;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;

    

    public void UpdateCounter()
    {
        text1.text = p1Score.score.ToString();
        text2.text = p2Score.score.ToString();
        text3.text = p3Score.score.ToString();
    }
}
