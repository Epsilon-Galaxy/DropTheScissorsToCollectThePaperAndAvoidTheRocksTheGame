using UnityEngine;

public class DraggableScissors : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody2D rb;
    private Vector3 initialPosition;  // Store the initial position of the scissors

    private Camera mainCamera;  // Reference to the main camera
    public LivesTracker livesTracker; 

    private void Start()
    {
        // Get the Rigidbody2D component of the scissors
        rb = GetComponent<Rigidbody2D>();
        // Initially set gravity to 0 so it doesn't fall while dragging
        rb.gravityScale = 0f;

        // Store the initial position
        initialPosition = transform.position;

        // Get the main camera
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Handle dragging
        if (isDragging)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Keep the scissors on the same plane (2D)
            transform.position = new Vector3(mousePosition.x + offset.x, transform.position.y, transform.position.z);
        }

        // Check if the scissors have fallen out of bounds (below the camera's view)
        if (transform.position.y < mainCamera.transform.position.y - mainCamera.orthographicSize)
        {
            ResetPosition(); // Reset the scissors if they fall below the camera
        }
    }

    private void OnMouseDown()
    {
        // Start dragging when the mouse clicks on the scissors
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        isDragging = true;

        // Disable gravity while dragging
        rb.gravityScale = 0f; // Prevent gravity from affecting the scissors while dragging
        rb.linearVelocity = Vector2.zero; // Stop any current velocity
    }

    private void OnMouseUp()
    {
        // Stop dragging and drop the scissors down
        isDragging = false;
        DropScissors();
    }

    private void DropScissors()
    {
        // Enable gravity to allow the scissors to fall naturally
        rb.gravityScale = 1f; // Enable gravity to let the scissors fall with gravity

        // Optionally adjust the initial velocity to add a slight downward motion
        // rb.velocity = new Vector2(0, -2f); // Uncomment this line to add a small downward velocity if you want
    }

    private void ResetPosition()
    {
        if (livesTracker.UseLife())
        {
            // Reset the scissors back to the initial position
            transform.position = initialPosition;
            rb.linearVelocity = Vector2.zero;  // Stop any current velocity
            rb.gravityScale = 0f; // Disable gravity until the scissors are dropped again
            rb.angularVelocity = 0f; // Stop any angular velocity (spinning)
            transform.rotation = Quaternion.identity; // Set the rotation back to 0 (no rotation)
        }
        else
        {
            // Game over logic
            Debug.Log("Game Over! No more scissors can be dropped.");
            this.enabled = false; // Disable this script
        }
    }
}
