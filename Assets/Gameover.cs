using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Gameover : MonoBehaviour
{

    public Text gameoverText;
    public Text completeText;
    public Text finalScoreText;
    public string sceneName = "Menu";
    MoveFoward plane;

    // Use this for initialization
    void Start()
    {
        plane = FindObjectOfType<MoveFoward>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dead()
    {
        plane.speed = 0;
        gameoverText.enabled = true;
        finalScoreText.text = "SCORE: " + GameManager.Instance.score;
        finalScoreText.enabled = true;
        Invoke("LoadMenu", 5.0f);
    }

    public void MissionComplete()
    {
        plane.speed = 0;
        completeText.enabled = true;
        finalScoreText.enabled = true;
        finalScoreText.text = "SCORE: " + GameManager.Instance.score;
        Invoke("LoadMenu", 5.0f);
    }

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
