using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    //=======Movement Variables========
    public float speed;
    private Rigidbody2D rb2d;
    public float jumpForce;
    private SpriteRenderer spriteRenderer;
    public float raycastLength = 0.4f;
    public LayerMask platformLayerMask;

    //==========Animation Variables=======
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //=======Animation Code========
        if (Input.GetKey(KeyCode.G))
        {
            //isItching = switcheroo(isItching);
            animator.SetTrigger("Lick2");
            //animator.SetBool("Lick2", false);
        }
        if (Input.GetKey(KeyCode.T))
        {

            //animator.SetBool("Itch", false);
        }


        //========Movement Code=======
        Vector2 vel = rb2d.velocity;
        Vector2 normalizedDir = rb2d.velocity.normalized;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (IsGround())
            {
                vel.y = jumpForce;
            }
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
        animator.SetFloat("run", Mathf.Abs(vel.x));
    }

    bool IsGround()//returns true if there is a platform below, false if not
    {
        Vector2 origin = transform.position;
        RaycastHit2D platformDown = Physics2D.Raycast(origin, Vector2.down, raycastLength, platformLayerMask);
        if (platformDown.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
