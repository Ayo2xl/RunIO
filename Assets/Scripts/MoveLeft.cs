using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private Playercontroller playerControllerScript;
    private float leftBound = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("player2D").GetComponent<Playercontroller>(); // Get the player controller script component from the player object
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false) {
            transform.Translate(Vector2.left * speed * Time.deltaTime); // Move the obstacle to the left
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacles")) // Check if the obstacle has passed the left boundary
        {
            Destroy(gameObject); // Destroy the obstacle when it passes the left boundary
        }
         
    }
}
