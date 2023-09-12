using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMouseClick : MonoBehaviour
{

    public GameObject catPrefab;
    private AudioSource myAudioSource;
    public AudioClip buttonSound;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        //button animation
        animator.SetTrigger("press");

        //button sound
        myAudioSource.PlayOneShot(buttonSound);

        //spawn cat
        Instantiate(catPrefab, new Vector3(-7, 5, 0), Quaternion.identity);
    }
}
