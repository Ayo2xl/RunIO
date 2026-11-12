using UnityEngine;

public class JumpTestScript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the GameObject
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 500f, ForceMode2D.Impulse); // Apply an upward force to make the player jump
            Debug.Log("Test Position: " + transform.position); 
        }
    }
}
