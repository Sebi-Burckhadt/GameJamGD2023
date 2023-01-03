using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCounter : MonoBehaviour
{

    public int score;
    public Counter counter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box")
        {
            score++;
            counter.UpdateCounter();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
      if(other.tag == "Box")
        {
            score--;
            counter.UpdateCounter();
        }  
    }
}
