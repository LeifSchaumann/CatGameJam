using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMouseClick : MonoBehaviour
{

    public GameObject catPrefab;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        //button animation
        animator.SetTrigger("press");

        //spawn cat
        Instantiate(catPrefab, new Vector3(-7, 5, 0), Quaternion.identity);
    }
}
