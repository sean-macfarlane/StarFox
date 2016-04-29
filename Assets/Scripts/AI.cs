using UnityEngine;
using System.Collections;

/// <summary>
/// Basic AI for Enemies
/// </summary>
public class AI : MonoBehaviour
{
    public float targetDistance = 75.0f;        //Distance from Player
    public float enemySpeed = 75.0f;     //Enemy Movement Speed
    public GameObject bullet;   //Enemy Bullet Prefab
    public float velocity = 150.0f;  // Enemy Bullet Velocity
    GameObject _plane;  //Game Plane
    float _destroyTime = 2.0f;  //Destroy Time of Bullet
    AudioSource _sound; //Sound of Bullet

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        _sound = GetComponent<AudioSource>();
        _plane = GameObject.FindGameObjectWithTag("GamePlane");
        InvokeRepeating("Shoot", 1.0f, 0.5f);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void LateUpdate()
    {
        if (transform.position.z - _plane.transform.position.z <= targetDistance)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = _plane.transform.position.z + targetDistance;
            transform.position = newPosition;
        }
        else
        {
            transform.position += transform.forward * enemySpeed * Time.deltaTime;
        }
    }

    ///<summary>
    ///Collision Detection for Enemy
    ///</summary>
    ///<param name=”collision”>The collision object the player has collided with</param>
    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;
        if (otherGO.tag == "Bullet")
        {
            _sound.Play();
            GameManager.Instance.AddScore(10);
            Destroy(otherGO);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Shoots Bullet
    /// </summary>
    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * velocity);
        Destroy(newBullet.gameObject, _destroyTime);
    }
}