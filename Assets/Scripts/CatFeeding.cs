using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFeeding : MonoBehaviour
{
    public int fishEaten = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Fish>())
        {
            fishEaten++;
            Destroy(collision.gameObject);
        }
    }
}
