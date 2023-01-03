using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float timer;
    public float startTime = 40;

    private void Start()
    {
        timer = startTime;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");
    }
}
