using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables related to Jump
    private float jumpForce = 10;
    private float gravityModifier = 2;
    private bool isOnGround = true;
    //Defines playerRb as a Rigidbody variable
    private Rigidbody playerRb;
    //Checks for game over
    public bool gameOver = false;


    void Start()
    {
        //Assigns the Rigidbody of the player character to playerRb
        playerRb = GetComponent<Rigidbody>();
        //Multiplies gravity of the Unity physics motor with GravityModifier
        Physics.gravity *= gravityModifier;
    }

    
    void Update()
    {
        Jump();
    }

    //Makes the player character jump when player presses space
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }


    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }

        else if (other.gameObject.tag == "Obstacle")
        {
            gameOver = true;
        }
    }
}
