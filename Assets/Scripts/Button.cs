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
            GameObject fish = Instantiate(fishPrefab, fishSpawner.position, Quaternion.identity);
        }
    }
}
