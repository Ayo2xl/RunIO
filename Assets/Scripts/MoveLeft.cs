using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20f;
    private Playercontroller playerControllerScript;
    private float leftBound = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("player2D").GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false) {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
         
    }
}
