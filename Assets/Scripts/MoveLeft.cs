using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //Speed at which the scene moves
    private float speed = 15;

    //Variable for Player Controller -script
    private PlayerController playerControllerScript;  

    //Point beyond which obstacles get destroyed
    private float leftBound = -15;

    void Start()
    {
        //Gets Player Controller from Player and assigns it to playerControllerScript
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        Move();
        DestroyObstacle();
    }

    //Moves things left
    void Move()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    //Destroys obstacles after a certain point
    void DestroyObstacle()
    {
        if (transform.position.x < leftBound && gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
