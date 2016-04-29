using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public int inverse = 1;
    public float _rotationSpeed = 50.0f;
    Tricks tricks;
    int _livesCount;        // The current amount of lives a Player has
    AudioSource hit;

    // Use this for initialization
    void Start()
    {
        hit = GetComponent<AudioSource>();
        tricks = FindObjectOfType<Tricks>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, (inverse) * vertical, 0);
        Vector3 finalDirection = new Vector3(horizontal, (inverse) * vertical, 1.0f);

        transform.position += direction * movementSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection), Mathf.Deg2Rad* _rotationSpeed);
    }

    ///<summary>
    ///Collision Detection for Player
    ///</summary>
    ///<param name=”collision”>The collision object the player has collided with</param>
    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;
        if (tricks.inTrick == false)
        {
            tricks.inTrick = true;
            if (otherGO.tag == "Enemy")
            {
                hit.Play();
                Destroy(otherGO);
                HealthManager.Instance.ChangeHealth(-10.0f);
            }
            else if (otherGO.tag == "Terrain")
            {
                hit.Play();
                HealthManager.Instance.ChangeHealth(-5.0f);
            }
            Invoke("TurnOnCollider", 2.0f);
        }
    }


    void TurnOnCollider()
    {
        tricks.inTrick = false;
    }
}
