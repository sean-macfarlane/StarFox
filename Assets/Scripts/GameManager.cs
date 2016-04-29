using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        gameObject.name = "$GameManager";
    }

    public Text scoreText;      // Text object for Score
    public int score;     // Score value

    string _highscoreKey = "VALUE_HIGHSCORE";   //Stores the Highscore
    AudioSource sound;

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        score = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    ///<summary>
    ///Updates the scoreboard
    ///</summary>
    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    ///<summary>
    ///Adds points to the current score
    ///</summary>
    ///<param name=”points”>The amount of points to add to the score</param>
    public void AddScore(int points)
    {
        sound.Play();
        score += points;
        UpdateScore();
    }

    ///<summary>
    ///Updates the highscore
    ///</summary>
    public void UpdateHighscore()
    {
        if (PlayerPrefs.GetInt(_highscoreKey) < score)
        {
            PlayerPrefs.SetInt(_highscoreKey, score);
        }
    }
}
