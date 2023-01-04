using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceBombs : MonoBehaviour
{
    public bool canPlaceBomb;
    public Explode explode;
    public GameObject cursor;
    public Vector3 newPosition;
    RaycastHit hit;
    public float lerpSpeed = 15f;
    public float loadTime = 1f;
    float timer;
    public Slider bombSlider;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        timer = loadTime;
        bombSlider.maxValue = loadTime;
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

        ThrowRayCast();


    }


    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            bombSlider.value = loadTime - timer;
        }


        if (canPlaceBomb)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (timer <= 0)
                {
                    explode.LaunchRocket();
                    timer = loadTime;
                }

            }
        }
        
    }
    void ThrowRayCast()
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
