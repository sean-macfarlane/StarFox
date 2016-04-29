using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///<summary>
///The GameController of the Start Screen
///</summary>
public class StartScreen : MonoBehaviour
{
    AudioSource _sound; //Menu Select Sound
    string _name;   //Name of the scene
    string _highscoreKey = "VALUE_HIGHSCORE";   //Stores the Highscore

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        if (!PlayerPrefs.HasKey(_highscoreKey))
        {
            PlayerPrefs.SetInt(_highscoreKey, 0);
        }
        _sound = GetComponent<AudioSource>();
    }

    ///<summary>
    ///Changes the Scene to the Scene with the name entered.
    ///</summary>
    ///<param name=”sceneName”>The name of the Scene to change to.</param>
    public void ChangeSceneWithName(string sceneName)
    {
        _name = sceneName;
        _sound.Play();
        Invoke("PlaySound", 2.0f);

    }

    /// <summary>
    /// Play the Sound and then switches scene
    /// </summary>
    void PlaySound()
    {
        if (_name.Equals("_scene"))
        {
            Destroy(FindObjectOfType<Music>().gameObject);
        }

        SceneManager.LoadScene(_name);
    }
}
