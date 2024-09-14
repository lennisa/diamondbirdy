using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of player movement
    public float rewindTime = 3f; // Time to rewind in seconds
    public KeyCode rewindKey = KeyCode.R; // Key to trigger rewind

    private Rigidbody2D rb;
    private Vector2[] pastPositions;
    private int pastPositionIndex;
    private float lastRewindTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        pastPositions = new Vector2[Mathf.CeilToInt(rewindTime * (1f / Time.fixedDeltaTime))];
        pastPositionIndex = 0;
        lastRewindTime = Time.time;
    }

    void Update()
    {
        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calculate the movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Move the player
        MovePlayer(movement);

        // Check for rewind input
        if (Input.GetKeyDown(rewindKey))
        {
            RewindPosition();
        }
    }

    void MovePlayer(Vector2 direction)
    {
        rb.velocity = direction * moveSpeed; // Set velocity for movement
        StorePastPosition(); // Store current position for rewind
    }

    void StorePastPosition()
    {
        pastPositions[pastPositionIndex] = transform.position;
        pastPositionIndex = (pastPositionIndex + 1) % pastPositions.Length;
    }

    void RewindPosition()
    {
        // Only allow rewind if enough time has passed since last rewind
        if (Time.time - lastRewindTime >= rewindTime)
        {
            lastRewindTime = Time.time;
            int rewindIndex = (pastPositionIndex - Mathf.CeilToInt(rewindTime * (1f / Time.fixedDeltaTime)) + pastPositions.Length) % pastPositions.Length;
            rb.position = pastPositions[rewindIndex];
        }
    }
}

