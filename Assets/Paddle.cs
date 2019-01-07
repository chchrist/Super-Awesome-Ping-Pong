using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float moveSpeed = 30.0f;
    public string playerInputAxis = "Player1";

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        float verticalInput = Input.GetAxisRaw(playerInputAxis);
        rb.velocity = new Vector2(0, verticalInput * moveSpeed);
    }

    /**
     * Resets paddles to default position.
     */
    public void Reset () {
        rb.velocity = Vector2.zero;
        if (playerInputAxis == "Player1") {
            transform.position = new Vector2(-5, 0);
        }
        else {
            transform.position = new Vector2(5, 0);
        }
    }
}
