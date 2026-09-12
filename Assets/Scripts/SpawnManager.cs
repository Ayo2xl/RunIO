using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(12.53f, 1.29f,11.76f);
    private float startDelay = 2;
    private float repeatRate = 3;
    private Playercontroller playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
         playerControllerScript = GameObject.Find("player2D").GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false){
             Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
       
    }
}
