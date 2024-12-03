using System;
using UnityEngine;

public class DraggableScissors : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody2D rb;
    private Vector3 initialPosition;

    private Camera mainCamera;
    public LivesTracker livesTracker;
    public GameObject GameOver;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        initialPosition = transform.position;
        mainCamera = Camera.main;

        if (GameOver != null)
        {
            GameOver.SetActive(false);
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = new Vector3(mousePosition.x + offset.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y < mainCamera.transform.position.y - mainCamera.orthographicSize)
        {
            ResetPosition();
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        isDragging = true;

        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        DropScissors();
    }

    private void DropScissors()
    {
        ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper.UseScissors();
        rb.gravityScale = 1f;
    }

    private void ResetPosition()
    {
        if (livesTracker != null && livesTracker.UseLife())
        {
            transform.position = initialPosition;
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0f;
            rb.angularVelocity = 0f;
            transform.rotation = Quaternion.identity;
        }
        else
        {
            if (GameOver != null)
            {
                GameOver.SetActive(true);
            }
            else
            {
                Debug.LogError("Game Over object is not assigned in the Inspector.");
            }

            this.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            ResetPosition();
        }
    }
}
