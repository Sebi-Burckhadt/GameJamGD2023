using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopIn : MonoBehaviour
{
    Vector3 startSize;
    Vector3 startPos;
    Vector2 randomRange = new Vector2(0.2f, 2.5f);
    float randomWaitTime;

    
    private void OnEnable()
    {
        startSize = transform.localScale;
        transform.localScale = Vector3.zero;
        // StartCoroutine(delayedScaler());
        MoveAndScaleToDestination();
        
    }

    


    void MoveAndScaleToDestination()
    {
        LeanTween.scale(gameObject, startSize, 0.5f).setEase(LeanTweenType.linear);
    }
}
