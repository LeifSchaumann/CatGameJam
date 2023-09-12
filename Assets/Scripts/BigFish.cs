using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFish : MonoBehaviour
{
    private Animator animator;
    private AudioSource myAudioSource;
    public AudioClip fishSound;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CatMovement>() != null)
        {
            //sound
            myAudioSource.PlayOneShot(fishSound);

            Camera.main.GetComponent<CameraScript>().goCrazy();
            animator.SetTrigger("decompose");
        }
        
    }
}
