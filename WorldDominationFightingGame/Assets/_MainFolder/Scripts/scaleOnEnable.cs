using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleOnEnable : MonoBehaviour
{
    public bool scaleUp;
    Vector3 startSize;

    private void OnEnable()
    {
        startSize = transform.localScale;
        if (scaleUp)
        {

            transform.localScale = Vector3.zero;
            LeanTween.scale(gameObject, startSize, 0.4f).setEase(LeanTweenType.easeOutElastic);
        }
        else
        {
            //LeanTween.scale(gameObject, Vector3.zero, 0.2f).setEase(LeanTweenType.easeInExpo);
        }
    }

    public void ScaleDown()
    {
        LeanTween.scale(gameObject, Vector3.zero, 0.1f).setEase(LeanTweenType.easeInExpo);
    }
}
