using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{

    public float targetDistance = 10.0f;
    public float enemySpeed = 0.0f;
    public GameObject bullet;
    public float velocity = 10.0f;
    GameObject plane;
    float destroyTime = 2.0f;
    AudioSource sound;

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        plane = GameObject.FindGameObjectWithTag("GamePlane");
        InvokeRepeating("Shoot", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.z - plane.transform.position.z <= targetDistance)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = plane.transform.position.z + targetDistance;
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
            sound.Play();
            GameManager.Instance.AddScore(10);
            Destroy(otherGO);
            Destroy(gameObject, 2.0f);
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * velocity);
        Destroy(newBullet.gameObject, destroyTime);        
    }
}