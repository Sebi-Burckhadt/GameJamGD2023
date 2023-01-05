using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnLandMass : MonoBehaviour
{
    public GameObject objectHolder;
    public int boxAmountX = 40;
    public int boxAmountY = 40;
    public GameObject objectToSpawn;
    public float offset = 25;
    public float spaceBetweenObjects = 0.41f;
    void Start()
    {
        //LeanTween.init(5000);
        for (int i = 0; i < boxAmountX; i++)
        {
            for (int j = 0; j < boxAmountY; j++)
            {
                GameObject snowBlock =  Instantiate(objectToSpawn, new Vector3((i - offset) * spaceBetweenObjects, 2.2f, (j - offset) * spaceBetweenObjects), Quaternion.identity, objectHolder.transform);
                StartCoroutine(DelayedEnable((i+j + 0f) * 0.01f, snowBlock));
            }
        }

       
    }

    IEnumerator DelayedEnable(float waitingTime, GameObject currentObject)
    {
        yield return new WaitForSeconds(waitingTime);
        currentObject.SetActive(true);
        //LeanTween.scale(currentObject, Vector3.one*.2f, 1f).setEase(LeanTweenType.easeOutExpo);
    }


}
