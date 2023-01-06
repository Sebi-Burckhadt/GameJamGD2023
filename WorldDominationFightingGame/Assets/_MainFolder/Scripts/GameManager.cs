using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public float gameTimer = 60;
    public TextMeshProUGUI alternativeCountdown;
    public TextMeshProUGUI trueCountdown;
    public TextMeshProUGUI finishedText;
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI sceneIsReloadableText;
    public GameObject scorePanel;
    public GameObject sceneReloader;
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


    public Transform cameraPlacementWin;
    public GameObject mainCamera;
    public GameObject humanModel;
    public GameObject whaleModel;
    public GameObject alienModel;

    public FMOD.Studio.EventInstance em;
    public EventReference humanWinSound;
    public EventReference whaleWinSound;
    public EventReference alienWinSound;
    public EventReference winSound;
    public EventReference startSound;
    public EventReference endSound;
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
        PlaySound(startSound);
        player1.canMove = true;
        player2.canMove = true;
        bombPlayer.canPlaceBomb = true;
        scoreCounter.StartMusic();
    }

    void EndGame()
    {
        PlaySound(endSound);
        player1.canMove = false;
        player2.canMove = false;
        bombPlayer.canPlaceBomb = false;
        finishedText.gameObject.SetActive(true);
        scorePanel.SetActive(false);
        StartCoroutine(FinishScene());
        scoreCounter.canAdjustSound = false;
        scoreCounter.removeSound();

    }

    IEnumerator FinishScene()
    {
        yield return new WaitForSeconds(1f);
        LeanTween.alphaCanvas(blackScreen, 1f, 0.2f).setEase(LeanTweenType.easeInCirc);
        yield return new WaitForSeconds(1f);
        LeanTween.alphaCanvas(blackScreen, 0f, 0.2f).setEase(LeanTweenType.easeInCirc);
        yield return new WaitForSeconds(1f);
        CalculateResults();
        MoveScene();
        finishedText.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneCanReload();
        yield return null;
    }


    void MoveScene()
    {
        mainCamera.transform.position = cameraPlacementWin.position;
        mainCamera.transform.rotation = cameraPlacementWin.rotation;
    }
    public void PlaySound(EventReference winSound)
    {
        em = FMODUnity.RuntimeManager.CreateInstance(winSound);
        em.start();
        em.release();
    }
    void CalculateResults()
    {
        List<PlayerScore> scores = new List<PlayerScore>
        {
            new PlayerScore(p1Name, scoreCounter.s1Percent, 0),
            new PlayerScore(p2Name, scoreCounter.s2Percent, 1),
            new PlayerScore(p3Name, scoreCounter.s3Percent, 2)
        };
        scores.Sort();

        PlayerScore first = scores[0];
        firstPlace = scores[0].PlayerName;
        secondPlace = scores[1].PlayerName;
        thirdPlace = scores[2].PlayerName;
        
        winnerText.text = "1st: " + firstPlace + " with " + scores[0].Score.ToString("F0") + "% of all snow."+ "\n\n2nd: " + secondPlace + " with " + scores[1].Score.ToString("0") + "% of all snow." + "\n\n3rd: " + thirdPlace + " with " + scores[2].Score.ToString("0") + "% of all snow." ;
        winnerText.gameObject.SetActive(true);

        PlaySound(winSound);
        //activate Human model
        if (scores[0].Index == 0)
        {
            humanModel.SetActive(true);
            PlaySound(humanWinSound);
        }
        //activate Whale model
        if (scores[0].Index == 1)
        {
            whaleModel.SetActive(true);
            PlaySound(whaleWinSound);
        }
        //activate Alien model
        if (scores[0].Index == 2)
        {
            alienModel.SetActive(true);
            PlaySound(alienWinSound);
        }
    }

    void SceneCanReload()
    {
        sceneReloader.SetActive(true);
        sceneIsReloadableText.gameObject.SetActive(true);
        scoreCounter.KillMusic();
    }
}


