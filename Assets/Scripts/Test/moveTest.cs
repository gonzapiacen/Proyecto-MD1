using UnityEngine;

public class moveTest : MonoBehaviour
{
    public float moveSpeed = 5f;   // Movement speed
    private Rigidbody rb;

    void Start()
    {
        // Cache the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from WASD/arrow keys
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Build movement vector
        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed;

        // Apply movement while keeping current Y velocity
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }

    void FixedUpdate()
    {
        
    }
}
