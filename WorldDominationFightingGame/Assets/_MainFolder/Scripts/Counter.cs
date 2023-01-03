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
    float s1Percent;
    float s2Percent;
    float s3Percent;
    float newMaxAmount;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;

    private void Start()
    {
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        s1 = p1Score.score;
        s2 = p2Score.score;
        s3 = p3Score.score;
        
        newMaxAmount = s1 + s2 + s3;
        s1Percent = ((s1 + 0f) / newMaxAmount) * 100f;
        s2Percent = ((s2 + 0f)/ newMaxAmount) * 100f;
        s3Percent = ((s3 + 0f)/ newMaxAmount) * 100f;

        text1.text = "Red Player: " + s1Percent.ToString("F2") + "%";
        text2.text = "Blue Player: " + s2Percent.ToString("F2") + "%";
        text3.text = "Yellow Player: " + s3Percent.ToString("F2") + "%";
    }
}
