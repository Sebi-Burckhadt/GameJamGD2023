using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    float angle;
    float speed = 15f;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        angle = Time.deltaTime * speed;
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), angle);
    }
}
