using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char1_AnimTest : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            animator.SetBool("Lick2", true);
            animator.SetBool("Lick2", false);
        }
        if (Input.GetKey(KeyCode.T))
        {
            animator.SetBool("Itch", true);
            animator.SetBool("Itch", false);
        }

    }
}
