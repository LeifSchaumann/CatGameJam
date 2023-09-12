using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animator;
    public Transform fishSpawner;
    public GameObject fishPrefab;
    public GameObject cam;
    private GameObject cat;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        cat = collision.gameObject;
        if (collision.GetComponent<CatMovement>())
        {
            //button animation
            animator.SetTrigger("press");

            //spawn fish
            Rigidbody2D fishRb = Instantiate(fishPrefab, fishSpawner.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            fishRb.angularVelocity = Random.Range(-500.0f, 500.0f);
            fishRb.velocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-1f, 1f));

            //camera starts following cat
            //cam.transform.SetParent(cat.transform, true);
            //cam.transform.position = new Vector3(cat.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        }
    }
}
