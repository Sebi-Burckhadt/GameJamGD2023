using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopIn : MonoBehaviour
{
    Vector3 startSize;
    Vector3 startPos;
    Vector2 randomRange = new Vector2(0.2f, 2.5f);
    float randomWaitTime;

    private void onEnable()
    {
        randomWaitTime = Random.Range(randomRange.x, randomRange.y);
        startSize = transform.localScale;
        startPos = transform.localPosition;
        transform.localPosition = new Vector3(startPos.x, (startPos.y + 10f), startPos.z);
        transform.localScale = Vector3.zero;
        // StartCoroutine(delayedScaler());
        MoveAndScaleToDestination();
        
    }

    IEnumerator delayedScaler()
    {
        yield return new WaitForSeconds(randomWaitTime);
        MoveAndScaleToDestination();
        yield return new WaitForSeconds(0.1f);
        transform.localScale = startSize;
        transform.localPosition = Vector3.zero;
        yield return null;
    }


    void MoveAndScaleToDestination()
    {
        LeanTween.scale(gameObject, startSize, 0.3f).setEase(LeanTweenType.linear);
        LeanTween.moveLocal(gameObject, Vector3.zero, 0.3f).setEase(LeanTweenType.linear);
    }
}
