using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SushiEating : MonoBehaviour
{
    public int sushiEaten = 0;
    public int sashimiEaten = 0;
    public int rawEaten = 0;
    public GameObject victoryText;
    
    //public GameObject UI;
    //private Label scoreLabel;
    private AudioSource eatSound;
    void Start()
    {
        //VisualElement root = UI.GetComponent<UIDocument>().rootVisualElement;
        //scoreLabel = root.Q<Label>("Score");

        eatSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sushiEaten >= 1 && sashimiEaten >= 1 && rawEaten >= 1)
        {
            victoryText.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Sushi>())
        {
            eatSound.Play();
            sushiEaten++;
            //scoreLabel.text = sushiEaten.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<Sashimi>())
        {
            eatSound.Play();
            sashimiEaten++;
            //scoreLabel.text = sashimiEaten.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<RawFish>())
        {
            eatSound.Play();
            rawEaten++;
            //scoreLabel.text = sushiEaten.ToString();
            Destroy(collision.gameObject);
        }
    }
}
