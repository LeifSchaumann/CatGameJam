using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFeeding : MonoBehaviour
{
    public int fishEaten = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fish"))
        {
            fishEaten++;
            Destroy(collision.gameObject);
        }
    }
}
