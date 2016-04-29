using UnityEngine;
using System.Collections;

/// <summary>
/// Shoot Controller
/// </summary>
public class Shoot : MonoBehaviour
{
    public Rigidbody bullet;        // Reference to the bullet prefab
    public float velocity = 10.0f;  // Velocity of bullet
    float _destroyTime = 3.0f;      //Time to destroy after

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            Rigidbody newBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
            Destroy(newBullet.gameObject, _destroyTime);
        }
    }
}
