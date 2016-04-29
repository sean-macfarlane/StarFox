using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///<summary>
///The GameController of the Start Screen
///</summary>
public class StartScreen : MonoBehaviour
{
    AudioSource sound;
    string _name;
    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    ///<summary>
    ///Changes the Scene to the Scene with the name entered.
    ///</summary>
    ///<param name=”sceneName”>The name of the Scene to change to.</param>
    public void ChangeSceneWithName(string sceneName)
    {
        _name = sceneName;
        sound.Play();
        Invoke("PlaySound", 2.0f);
        
    }

    void PlaySound()
    {
        SceneManager.LoadScene(_name);
    }
}
