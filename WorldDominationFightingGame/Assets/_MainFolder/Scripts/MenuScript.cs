using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public CanvasGroup mainPanel;
    public CanvasGroup whereToSit;
    public CanvasGroup instructions;
    public CanvasGroup blackScreen;


    public void ChangeToWhereToSit()
    {
        
        whereToSit.gameObject.SetActive(true);

        LeanTween.alphaCanvas(mainPanel, 0, .2f).setEase(LeanTweenType.easeOutCirc);
        LeanTween.alphaCanvas(whereToSit, 1, .2f).setEase(LeanTweenType.easeOutCirc);
        LeanTween.delayedCall(0.2f, () => mainPanel.gameObject.SetActive(false));
    }

    public void ChangeToInstructions()
    {
        instructions.gameObject.SetActive(true);
        LeanTween.alphaCanvas(instructions, 1, .2f).setEase(LeanTweenType.easeOutCirc);
        LeanTween.delayedCall(0.2f, () => whereToSit.gameObject.SetActive(false));
    }

    public void ChangeToMainScene()
    {
        blackScreen.gameObject.SetActive(true);
        LeanTween.alphaCanvas(blackScreen, 1, .2f).setEase(LeanTweenType.easeOutCirc);
        LeanTween.delayedCall(0.2f, () => Application.Quit());
        LeanTween.delayedCall(0.2f, () => SceneManager.LoadScene("MainScene"));
    }

    public void ExitGame()
    {
        blackScreen.gameObject.SetActive(true);
        LeanTween.alphaCanvas(blackScreen, 1, .2f).setEase(LeanTweenType.easeOutCirc);
        LeanTween.delayedCall(0.2f, () => Application.Quit());

    }

}
