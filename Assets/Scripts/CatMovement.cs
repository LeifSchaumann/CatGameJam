using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public float jumpForce;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb2d.velocity;
        Vector2 normalizedDir = rb2d.velocity.normalized;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            vel.y = jumpForce;
        }
        vel.x = Input.GetAxis("Horizontal") * speed;

        rb2d.velocity = vel;
        if (vel.x > 0.01)
        {
            spriteRenderer.flipX = false;
        }
        else if (vel.x < -0.01)
        {
            spriteRenderer.flipX = true;
        }
    }
}
