using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SushiEating : MonoBehaviour
{
    public int sushiEaten = 0;
    public int sashimiEaten = 0;
    public int steakEaten = 0;
    public GameObject UI;
    public GameObject victoryText;
    private AudioSource eatSound;
    Label sushiLabel;
    Label sashimiLabel;
    Label steakLabel;
    void Start()
    {
        VisualElement root = UI.GetComponent<UIDocument>().rootVisualElement;
        sushiLabel = root.Q<Label>("sushiScore");
        sashimiLabel = root.Q<Label>("sashimiScore");
        steakLabel = root.Q<Label>("steakScore");
        eatSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sushiEaten > 1 && sashimiEaten > 1 && steakEaten >= 1)
        {
            victoryText.GetComponent<SpriteRenderer>().enabled = true;
            Invoke("ChangeScene", 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Sushi>())
        {
            eatSound.Play();
            sushiEaten++;
            sushiLabel.text = sushiEaten.ToString() + "/2";
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<Sashimi>())
        {
            eatSound.Play();
            sashimiEaten++;
            sashimiLabel.text = sashimiEaten.ToString() + "/2";
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<RawFish>())
        {
            eatSound.Play();
            steakEaten++;
            steakLabel.text = steakEaten.ToString() + "/2";
            Destroy(collision.gameObject);
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
