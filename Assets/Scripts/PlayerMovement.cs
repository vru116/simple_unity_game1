using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public int speed = 5;
    public float jumpForce = 3f;
    private bool isOnGround = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(movementX * speed, rb2D.velocity.y);

        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isOnGround = false;
            Debug.Log("false");
        }

        CheckOutOfBounds();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("true");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            Debug.Log("false");
        }
    }

    void CheckOutOfBounds()
    {
        Camera mainCamera = Camera.main;

        float leftBound = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightBound = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float downBound = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        float upBound = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        if (transform.position.x < leftBound || transform.position.x > rightBound||
            transform.position.y < downBound || transform.position.y > upBound)
        {
            RestartGame();
        }
    }
    void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
