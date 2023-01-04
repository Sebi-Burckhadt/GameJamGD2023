using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLandMass : MonoBehaviour
{
    public GameObject objectHolder;
    public int boxAmountX = 40;
    public int boxAmountY = 40;
    public GameObject[] objectsToAnimate;
    public GameObject objectToSpawn;
    public float offset = 25;
    Vector3 startScale;
    int length;
    private void Awake()
    {
        length = objectsToAnimate.Length;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject g in objectsToAnimate)
        {
            startScale = g.transform.localScale;
            g.transform.localScale = Vector3.zero;
            //LeanTween.scale(g, startScale, 0.5f).setEase(LeanTweenType.easeOutElastic);
        }
        StartCoroutine(DelaySpawn());

        for (int i = 0; i < boxAmountX; i++)
        {
            for (int j = 0; j < boxAmountY; j++)
            {
                Instantiate(objectToSpawn, new Vector3((i-offset)*0.21f, 0.5f, (j-offset)*0.21f), Quaternion.identity, objectHolder.transform);
            }
        }
    }

    IEnumerator DelaySpawn()
    {
        for(int i = 0; i < length; i++)
        {
            
           LeanTween.scale(objectsToAnimate[i], startScale, 0.5f).setEase(LeanTweenType.easeOutElastic);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
