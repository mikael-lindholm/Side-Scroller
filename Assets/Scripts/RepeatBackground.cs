using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    //Variable for starting position
    private Vector3 startPos;

    //Variable for the halfway point of background image
    private float repeatWidth;

    void Start()
    {
        //Saves the starting position of the background
        startPos = transform.position;
        //Sets repeatWidth at background's halfway point
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
