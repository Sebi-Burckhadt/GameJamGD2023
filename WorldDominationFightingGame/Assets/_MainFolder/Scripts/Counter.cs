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
    public float s1Percent;
    public float s2Percent;
    public float s3Percent;
    float newMaxAmount;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;

    public RectTransform panel1;
    public RectTransform panel2;
    public RectTransform panel3;

    public float maxWidth = 620;
    public float minWidth = 250;
    float fullWidth;
    float difference;
    public float heightPanel = 150f;
    private void Start()
    {
        
        difference = maxWidth - minWidth;
        fullWidth = difference * 3;
        UpdateCounter();
        StartCoroutine(DelayResettedTextPos());
        
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

        text1.text = "Human: " + s1Percent.ToString("F2") + "%";
        text2.text = "Whale: " + s2Percent.ToString("F2") + "%";
        text3.text = "Insect: " + s3Percent.ToString("F2") + "%";

        //calculate with of panel that the width doesnt fall below the minWidth(250px) the three dont exeed the maxwidth+250*3
        panel1.sizeDelta = new Vector2(((fullWidth / 100) * s1Percent) + minWidth, heightPanel);
        panel2.sizeDelta = new Vector2(((fullWidth / 100) * s2Percent) + minWidth, heightPanel);
        panel3.sizeDelta = new Vector2(((fullWidth / 100) * s3Percent) + minWidth, heightPanel);

        
    }

    IEnumerator DelayResettedTextPos()
    {
        yield return new WaitForSeconds(0.1f);
        text1.GetComponent<RectTransform>().localPosition = Vector3.zero;
        text2.GetComponent<RectTransform>().localPosition = Vector3.zero;
        text3.GetComponent<RectTransform>().localPosition = Vector3.zero;
        yield return null;
    }
}
