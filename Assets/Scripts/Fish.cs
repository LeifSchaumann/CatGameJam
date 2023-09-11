using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    public Sprite[] coloredSprites;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();

        sr.sprite = coloredSprites[Random.Range(0, coloredSprites.Length)];
    }

    private void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

}
