using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFish : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CatMovement>() != null)
        {
            Camera.main.GetComponent<CameraScript>().goCrazy();
            animator.SetTrigger("decompose");
        }
        
    }
}
