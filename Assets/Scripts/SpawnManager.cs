using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Array of the prefabs of spawnable obstacles
    [SerializeField] private GameObject[] obstaclePrefabs;

    //Index number for which obstacle to spawn
    private int obstacleIndex = 0;

    //Spawn position
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    //Delay at start
    private float startDelay = 2;

    //Intervals at which obstacles are spawned
    private float repeatRate = 2;
    
    //Player Controller -script
    private PlayerController playerControllerScript;

    void Start()
    {
        //Repeats SpawnObstacle at repeatRate intervals after startDelay
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        //Gets Player Controller from Player and assigns it to playerControllerScript
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    //Spawns an obstacle at spawnPos position
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            //Instantiates an obstacle
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
            //Changes obstacleIndex to a random integer from 0 to 2
            obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        }
    }
}
