using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatFeeding : MonoBehaviour
{
    public int fishEaten = 0;

    private void Update()
    {
        if (fishEaten == 5)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Fish>())
        {
            Camera.main.GetComponent<CameraScript>().goCrazy();
            fishEaten++;
            Destroy(collision.gameObject);
        }
    }
}
