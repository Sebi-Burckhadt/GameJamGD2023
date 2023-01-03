using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBombs : MonoBehaviour
{
    public GameObject cursor;
    public Vector3 newPosition;
    RaycastHit hit;
    public float lerpSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        newPosition = Input.mouse;
        newPosition.y = 0;
        cursor.transform.position = newPosition;
    }*/

    private void FixedUpdate()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 10)))
        {
            //dragStartPosition = hit.point;

            newPosition = hit.point;// dragCurrentPosition;
        }
        cursor.transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpSpeed);


    }
}
