using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePingPong : MonoBehaviour
{
    Vector3 startPos;
    Vector3 newPos;
    public float offset = 1f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        newPos = new Vector3(startPos.x, startPos.y + offset, startPos.z);
        LeanTween.move(gameObject, newPos, 3f).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
