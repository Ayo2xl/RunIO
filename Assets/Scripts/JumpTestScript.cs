using UnityEngine;

public class JumpTestScript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 500f, ForceMode2D.Impulse);
            Debug.Log("Test Position: " + transform.position);
        }
    }
}
