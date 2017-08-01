using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{

    private int score, highscore;
    public GameObject scoreText, highscoreText;


    // Use this for initialization
    void Start()
    {
        scoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("score").ToString();
        highscoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadMainMenu()
    {
        Application.LoadLevel(0);
    }
}
