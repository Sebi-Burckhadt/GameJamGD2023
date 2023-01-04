using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameTimer = 60;
    public TextMeshProUGUI alternativeCountdown;
    public TextMeshProUGUI trueCountdown;
    public TextMeshProUGUI finishedText;
    public TextMeshProUGUI winnerText;
    public CanvasGroup blackScreen;
    public Movement player1;
    public Movement player2;
    public PlaceBombs bombPlayer;
    public Counter scoreCounter;
    

    float firstTimer = 3;
    float timer;
    bool startTimerBool;
    bool gameTimerBool;
    bool endTimerBool;

    bool once = true;

    public string p1Name;
    public string p2Name;
    public string p3Name;
    string firstPlace;
    string secondPlace;
    string thirdPlace;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen.alpha = 1;
        LeanTween.alphaCanvas(blackScreen, 0, 0.2f).setEase(LeanTweenType.easeInCirc);
        timer = firstTimer;
        startTimerBool = true;
        trueCountdown.gameObject.SetActive(false);
        finishedText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if (gameTimerBool)
            {
                UpdateTimerText();
                //when only 5 secs remain make the timer ping pong
                if (timer <= 5)
                {
                    if (once)
                    {
                        once = false;
                        EndTimerPingPong();
                    }
                }
                
            }else if(startTimerBool)
            {
                UpdateAlternativeTimer();
            }
            
        }
        else
        {
            
            if (gameTimerBool)
            {
                trueCountdown.gameObject.SetActive(false);
                EndGame();
                gameTimerBool = false;
                endTimerBool = true;
            }
            if (startTimerBool)
            {
                StartGame();
                trueCountdown.gameObject.SetActive(true);
                alternativeCountdown.gameObject.SetActive(false);
                startTimerBool = false;
                gameTimerBool = true;
                timer = gameTimer;
            }
            
            
        }
    }

    void EndTimerPingPong()
    {
        LeanTween.scale(trueCountdown.gameObject, Vector3.one * 2, 0.75f).setLoopPingPong();
        
    }

    void UpdateAlternativeTimer()
    {
        alternativeCountdown.text = timer.ToString("F0");
    }
    void UpdateTimerText()
    {
        trueCountdown.text =  timer.ToString("F2");
    }

    void StartGame()
    {
        player1.canMove = true;
        player2.canMove = true;
        bombPlayer.canPlaceBomb = true;
    }

    void EndGame()
    {
        player1.canMove = false;
        player2.canMove = false;
        bombPlayer.canPlaceBomb = false;
        finishedText.gameObject.SetActive(true);
        StartCoroutine(FinishScene());
    }

    IEnumerator FinishScene()
    {
        yield return new WaitForSeconds(2f);
        LeanTween.alphaCanvas(blackScreen, 1, 0.2f).setEase(LeanTweenType.easeInCirc);
        yield return new WaitForSeconds(1f);
        CalculateResults();
        yield return null;
    }
    void CalculateResults()
    {
        List<PlayerScore> scores = new List<PlayerScore>
        {
            new PlayerScore(p1Name, scoreCounter.s1Percent),
            new PlayerScore(p2Name, scoreCounter.s2Percent),
            new PlayerScore(p3Name, scoreCounter.s3Percent)
        };
        scores.Sort();

        PlayerScore first = scores[0];
        firstPlace = scores[0].PlayerName;
        secondPlace = scores[1].PlayerName;
        thirdPlace = scores[2].PlayerName;

        winnerText.text = "1st: " + firstPlace + "\n2nd: " + secondPlace + "\n3rd: " + thirdPlace ;
        winnerText.gameObject.SetActive(true);
    }

    
}


