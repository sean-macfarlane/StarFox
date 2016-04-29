using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Health Manager
/// </summary>
public class HealthManager : MonoBehaviour
{
    private static HealthManager instance = null;
    /// <summary>
    /// Singleton Health Manager
    /// </summary>
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
    }

    public float maxHealth = 100.0f;    //Max Player Health
    float _currentHealth;   //Current Player Health
    AudioSource _sound; //Sound of Damage
    Gameover _gameover; //Gameover Instance

    /// <summary>
    ///  Use this for initialization
    /// </summary>
    void Start()
    {
        _sound = GetComponent<AudioSource>();
        _currentHealth = maxHealth;
        _gameover = FindObjectOfType<Gameover>();
    }

    /// <summary>
    /// Change Player Health Amount
    /// </summary>
    /// <param name="amount"></param>
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
            _sound.Play();
            _gameover.Dead();           
        }
    }

    /// <summary>
    /// Returns the Current Player Health
    /// </summary>
    /// <returns></returns>
    public float getCurrentHealth()
    {
        return _currentHealth;
    }
}
