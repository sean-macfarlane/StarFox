using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    private static HealthManager instance = null;
    public static HealthManager Instance
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
        gameObject.name = "$HealthManager";
    }

    public float maxHealth = 100.0f;
    float _currentHealth;
    AudioSource sound;
    Gameover gameover;

    // Use this for initialization
    void Start()
    {
        _currentHealth = maxHealth;
        gameover = FindObjectOfType<Gameover>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHealth(float amount)
    {
        _currentHealth += amount;

        if (_currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }
        else if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            sound.Play();
            gameover.Dead();           
        }
    }

    public float getCurrentHealth()
    {
        return _currentHealth;
    }
}
