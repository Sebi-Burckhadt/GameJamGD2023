using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnableOneByOne : MonoBehaviour
{
    public Transform[] allSnow;
    Transform[] tempSnow;
    public void EnableObjects()
    {
        // Get an array of all the child game objects of this game object, including inactive game objects
        //allSnow = GetComponentsInChildren<GameObject>(true);




        tempSnow = GetComponentsInChildren<Transform>();

        allSnow = tempSnow.Where((val, idx) => idx != 0).ToArray();

        foreach (Transform t in allSnow)
        {
            t.gameObject.SetActive(false);
        }
        allSnow[0].gameObject.SetActive(true);

        for (int i = 1; i < allSnow.Length; i++)
        {


            // Make the next object appear after a delay
            StartCoroutine(DelayedEnable((i+0f)*0.001f, i));
        }
    }

    IEnumerator DelayedEnable(float waitingTime, int currentObject)
    {
        yield return new WaitForSeconds(waitingTime);
        allSnow[currentObject].gameObject.SetActive(true);
        
    }
}
