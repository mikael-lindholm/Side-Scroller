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

    //Defines playerAnim as an Animator variable
    private Animator playerAnim;


    void Start()
    {
        //Assigns the Animator of the player character to playerAnim
        playerAnim = GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }


    private void OnCollisionEnter(Collision other) 
    {
        //Changes isOnGround back to true when player character hits ground
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }

        //Changes gameOver to true and plays death animation when player character hits an obstacle
        else if (other.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
