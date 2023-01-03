using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLandMass : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    Vector3 startScale;
    int length;
    private void Awake()
    {
        length = objectsToSpawn.Length;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject g in objectsToSpawn)
        {
            startScale = g.transform.localScale;
            g.transform.localScale = Vector3.zero;
            //LeanTween.scale(g, startScale, 0.5f).setEase(LeanTweenType.easeOutElastic);
        }
        StartCoroutine(DelaySpawn());
    }

    IEnumerator DelaySpawn()
    {
        for(int i = 0; i < length; i++)
        {
            
           LeanTween.scale(objectsToSpawn[i], startScale, 0.5f).setEase(LeanTweenType.easeOutElastic);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
