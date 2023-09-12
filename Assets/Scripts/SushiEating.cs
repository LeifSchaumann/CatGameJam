using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SushiEating : MonoBehaviour
{
    public int sushiEaten = 0;
    public int sashimiEaten = 0;
    public int rawEaten = 0;
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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Sushi>())
        {
            eatSound.Play();
            sushiEaten++;
            //scoreLabel.text = sushiEaten.ToString() + "/3";
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<Sashimi>())
        {
            eatSound.Play();
            sashimiEaten++;
            //scoreLabel.text = sashimiEaten.ToString() + "/3";
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<RawFish>())
        {
            eatSound.Play();
            sushiEaten++;
            //scoreLabel.text = sushiEaten.ToString() + "/3";
            Destroy(collision.gameObject);
        }
    }
}
