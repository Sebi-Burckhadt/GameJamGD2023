using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    Vector3 inbetween;
    bool canLookAt;
    public bool targetIsCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (targetIsCamera)
        {
            target = Camera.main.transform;
        }
        if (target == null)
        {
            canLookAt = false;
        }
        else
        {
            canLookAt = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (canLookAt)
        {

            transform.LookAt(target, Vector3.up);
            inbetween = transform.rotation.eulerAngles;
            inbetween = new Vector3(0, inbetween.y + 180f, 0);
            transform.rotation = Quaternion.Euler(inbetween);
            //transform.rotation.eulerAngles = (0, transform.rotation.eulerAngles.y, 0);
            //transform.rotation.ToAngleAxis(out Vector3.up, 0);
            //transform.rotation.SetLookRotation(target.position, Vector3.up);
        }
    }
}
