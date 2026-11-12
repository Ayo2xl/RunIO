using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{
    public float jumpHeight = 2f; // The height the player will jump to
    public float jumpDuration = 0.6f; // The duration of the jump
    public TextMeshProUGUI gameOverText; // The text to display when the game is over
    public bool isGrounded = true; // Indicates if the player is on the ground
    public bool gameOver; // Indicates if the game is over
    public Button restartButton;
    public Button exitButton;
    public ParticleSystem explosionParticle;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private Vector3 startPos;
    private bool isJumping = false;
    private float jumpTimer = 0f;
    private Animator anim;

    void Start() // this run when the scene starts
    {
        startPos = transform.position;
        anim = GetComponentInChildren<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update() // this run every frame and updates the player's position
    {
        if (gameOver) return; // stop all further input/movement once game is over

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping) // Check if the space key is pressed and the player is grounded and not already jumping
        {
            isJumping = true;
            isGrounded = false;
            jumpTimer = 0f;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (isJumping)
        {
            jumpTimer += Time.deltaTime; // Update the jump timer with the time elapsed since the last frame
            float progress = jumpTimer / jumpDuration; // Calculate the progress of the jump as a fraction of the jump duration
            //time.delta is the time elapsed since the last frame it makes the movement speed the same reardless of frame rate 


            if (progress >= 1f) // Check if the jump has completed
            {
                progress = 1f; // Set the progress to 1 to indicate the jump is complete
                isJumping = false; // Mark the jump as no longer in progress
                isGrounded = true; // Mark the player as grounded again
            }

            float heightOffset = jumpHeight * 4 * progress * (1 - progress); // Calculate the height offset for the jump arc
            transform.position = new Vector3(startPos.x, startPos.y + heightOffset, startPos.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Game Over");
            explosionParticle.Play();
            gameOver = true;
            if (anim != null) anim.enabled = false; // freeze her animation on the hit frame
            playerAudio.PlayOneShot(crashSound, 1.0f);
            GameOver();
            restartButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
        }
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // Display the game over text
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene to restart the game
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}