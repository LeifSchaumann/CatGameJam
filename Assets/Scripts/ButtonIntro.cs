using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonIntro : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CatMovement>())
        {
            animator.SetTrigger("press");
            Invoke("ChangeScene", 0.5f);
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
