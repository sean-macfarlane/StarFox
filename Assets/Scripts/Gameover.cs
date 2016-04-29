using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Controller of the End of Game
/// </summary>
public class Gameover : MonoBehaviour
{
    public Text gameoverText;       //Gameover text
    public Text completeText;       //Complete Mission text
    public Text finalScoreText;     //Final score text
    public string sceneName = "Menu";       //Scene Name to Menu
    MoveFoward _plane;      //Game Plane
    string _highscoreKey = "VALUE_HIGHSCORE";   //Stores the Highscore

    // Use this for initialization
    void Start()
    {
        _plane = FindObjectOfType<MoveFoward>();
    }

    /// <summary>
    /// When Dead
    /// </summary>
    public void Dead()
    {
        _plane.speed = 0;
        gameoverText.enabled = true;
        finalScoreText.text = "SCORE: " + GameManager.Instance.score;
        finalScoreText.enabled = true;
        if (PlayerPrefs.GetInt(_highscoreKey) < GameManager.Instance.score)
        {
            PlayerPrefs.SetInt(_highscoreKey, GameManager.Instance.score);
        }
        Invoke("LoadMenu", 5.0f);
    }

    /// <summary>
    /// When Mission Complete
    /// </summary>
    public void MissionComplete()
    {
        _plane.speed = 0;
        completeText.enabled = true;
        finalScoreText.enabled = true;
        finalScoreText.text = "SCORE: " + GameManager.Instance.score;
        if (PlayerPrefs.GetInt(_highscoreKey) < GameManager.Instance.score)
        {
            PlayerPrefs.SetInt(_highscoreKey, GameManager.Instance.score);
        }
        Invoke("LoadMenu", 5.0f);
    }

    /// <summary>
    /// Load the Main Menu Scene
    /// </summary>
    void LoadMenu()
    {
        SceneManager.LoadScene(sceneName);
    }

    ///<summary>
    ///Collision Detection for Player
    ///</summary>
    ///<param name=”collision”>The collision object the player has collided with</param>
    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;
        if (otherGO.tag == "Player")
        {
            MissionComplete();
        }
    }
}
