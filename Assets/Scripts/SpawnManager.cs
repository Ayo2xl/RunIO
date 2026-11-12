using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(12.53f, 1.29f,11.76f); // Set the spawn position for obstacles
    private float startDelay = 2; // Set the initial delay before the first obstacle spawns
    private float repeatRate = 1.5f; // Set the interval between obstacle spawns
    private Playercontroller playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // Start repeatedly spawning obstacles after the initial delay
         playerControllerScript = GameObject.Find("player2D").GetComponent<Playercontroller>(); // Get the player controller script component from the player object
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false){ // Check if the game is not over
             Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); // Instantiate the obstacle at the spawn position
        }
       
    }
}
