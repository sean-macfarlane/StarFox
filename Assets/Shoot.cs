using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public float velocity = 10.0f;
    float destroyTime = 3.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            Rigidbody newBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
            Destroy(newBullet.gameObject, destroyTime);
        }
    }
}
