using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Displays Health Bar
/// </summary>
public class HealthBar : MonoBehaviour
{
    Image _healthBar;     // Health Bar

    /// <summary>
    /// Get Health Bar Image
    /// </summary>
    void Start()
    {
        _healthBar = GetComponent<Image>();
    }

    /// <summary>
    /// Fill the Health Bar
    /// </summary>
    void Update()
    {
        _healthBar.fillAmount = HealthManager.Instance.getCurrentHealth() / 100.0f;
    }
}