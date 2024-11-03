using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
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
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
