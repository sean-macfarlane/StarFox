using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Sets the Highscore for HighScore Menu Screen
/// </summary>
public class highscores : MonoBehaviour
{
    public Text highscore;  //Highscore Text
    string _highscoreKey = "VALUE_HIGHSCORE";   //Stores the Highscore

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        if (PlayerPrefs.HasKey(_highscoreKey))
        {
            highscore.text = PlayerPrefs.GetInt(_highscoreKey).ToString();
        }
    }

}
