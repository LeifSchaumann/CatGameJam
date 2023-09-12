using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevel2 : MonoBehaviour
{
    private Animator animator;
    public Transform[] spawners;
    public GameObject[] prefabs;
    private GameObject randomPrefab;
    private Transform randomSpawn;
    private AudioSource myAudioSource;
    public AudioClip buttonSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        randomSpawn = spawners[Random.Range(0, spawners.Length)];
        randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
                
        if (collision.GetComponent<CatMovement>())
        {
            //button animation
            animator.SetTrigger("press");

            //button sound
            myAudioSource.PlayOneShot(buttonSound);

            //spawn fish
            Rigidbody2D fishRb = Instantiate(randomPrefab, randomSpawn.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        }
    }

}
