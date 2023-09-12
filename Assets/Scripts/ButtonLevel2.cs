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

    void Start()
    {
        animator = GetComponent<Animator>();
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

            //spawn fish
            Rigidbody2D fishRb = Instantiate(randomPrefab, randomSpawn.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        }
    }

}
