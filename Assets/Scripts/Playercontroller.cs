using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{
    public float jumpHeight = 2f;
    public float jumpDuration = 0.6f;
    public TextMeshProUGUI gameOverText;
    public bool isGrounded = true;
    public bool gameOver;
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

    void Start()
    {
        startPos = transform.position;
        anim = GetComponentInChildren<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameOver) return; // stop all further input/movement once game is over

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            isJumping = true;
            isGrounded = false;
            jumpTimer = 0f;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            float progress = jumpTimer / jumpDuration;
            


            if (progress >= 1f)
            {
                progress = 1f;
                isJumping = false;
                isGrounded = true;
            }

            float heightOffset = jumpHeight * 4 * progress * (1 - progress);
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
        gameOverText.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}