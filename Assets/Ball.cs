using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float moveSpeed = 10;

    private Rigidbody2D rb;
    private Controller controller;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        controller = (Controller)FindObjectOfType(typeof(Controller));
        rb.velocity = Vector2.right * moveSpeed;
    }

    void FixedUpdate() {
        if (rb.velocity.magnitude > moveSpeed) {
            rb.velocity = rb.velocity.normalized * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        // Calculate direction of ball
        // ---------------------------
        float yVector = (transform.position.y - col.transform.position.y) / 
                     col.collider.bounds.size.y;

        // Apply new velocity to the ball
        // ------------------------------
        Vector2 velocity;

        if (col.gameObject.name == "Paddle1") {
            velocity = new Vector2(1, yVector).normalized;
            rb.velocity = velocity * moveSpeed;
        }
        else if (col.gameObject.name == "Paddle2") {
            velocity = new Vector2(-1, yVector).normalized;
            rb.velocity = velocity * moveSpeed;
        }
        else if (col.gameObject.name == "LeftWall") {
            controller.AddPoint("Player2");
            Reset();
        }
        else if (col.gameObject.name == "RightWall") {
            controller.AddPoint("Player1");
            Reset();
        }
    }

    /*
     * Resets ball to default position.
     */
    public void Reset () {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        rb.velocity = Vector2.right * moveSpeed;
    }
}
