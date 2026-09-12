using UnityEngine;
using UnityEngine.InputSystem;

public class PlayercontrollerScript : MonoBehaviour
{
    private Rigidbody2D Player2drb;
    public InputAction jumpMovement;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isGrounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player2drb = GetComponent<Rigidbody2D>();
        jumpMovement.Enable();
        Player2drb.gravityScale *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(jumpMovement.triggered && isGrounded)
        {
            Player2drb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
