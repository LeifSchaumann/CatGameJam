using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CatFeeding : MonoBehaviour
{
    public int fishEaten = 0;
    public GameObject UI;

    private Label scoreLabel;
    private AudioSource eatSound;

    private void Start()
    {
        VisualElement root = UI.GetComponent<UIDocument>().rootVisualElement;
        scoreLabel = root.Q<Label>("Score");

        eatSound = GetComponent<AudioSource>();
    }

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
            eatSound.Play();
            fishEaten++;
            scoreLabel.text = fishEaten.ToString() + "/5";
            Destroy(collision.gameObject);
        }
        //if (collision.GetComponent<BigFish>())
        //{
        //    
        //}
    }
}
