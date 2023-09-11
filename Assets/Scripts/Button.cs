using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animator;
    public Transform fishSpawner;
    public GameObject fishPrefab;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CatMovement>())
        {
            animator.SetTrigger("press");
            Rigidbody2D fishRb = Instantiate(fishPrefab, fishSpawner.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            fishRb.angularVelocity = Random.Range(-500.0f, 500.0f);
            fishRb.velocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-1f, 1f));
        }
    }
}
