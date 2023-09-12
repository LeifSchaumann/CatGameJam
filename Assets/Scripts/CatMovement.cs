using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public float jumpForce;
    private SpriteRenderer spriteRenderer;
    public float raycastLength = 0.4f;
    public LayerMask platformLayerMask;
    private bool isGrounded;
    public Animator animator;
    private float idleActionTimer = 0;
    private float idleActionTimerGoal;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        idleActionTimerGoal = Random.Range(5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the cat is grounded, update isGrounded

        RaycastHit2D groundCheckHit = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, platformLayerMask);
        if (groundCheckHit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Jumping and horizontal movement

        Vector2 vel = rb2d.velocity;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                vel.y = jumpForce;
            }
        }
        vel.x = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = vel;

        // Flip X depending on which direction the cat is moving

        if (vel.x > 0.01)
        {
            spriteRenderer.flipX = false;
        }
        else if (vel.x < -0.01)
        {
            spriteRenderer.flipX = true;
        }

        // Send info to animator

        animator.SetBool("isGrounded", isGrounded);

        if (Mathf.Abs(vel.x) > 0.01 && isGrounded)
        {
            animator.SetBool("isRunning", true);
            idleActionTimer = 0;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Trigger animations

        idleActionTimer += Time.deltaTime;
        if (idleActionTimer >= idleActionTimerGoal)
        {
            animator.SetTrigger("Lick2");
            idleActionTimer = 0;
            idleActionTimerGoal = Random.Range(5f, 15f);
        }



        // Restart the scene if the cat falls out of bounds

        if (transform.position.y < -6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Have reached script");

    //}
}
