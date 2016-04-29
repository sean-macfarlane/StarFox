using UnityEngine;
using System.Collections;

///<summary>
///The Controller for a Player: including movement, handling collisions, animations, and destruction.
///</summary>
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10.0f; //movement speed of Player
    public int inverse = 1; //Determine Inverse Controls 
    public float rotationSpeed = 50.0f;    //Rotation Speed of Player  

    Tricks _tricks;     //Reference to Tricks 
    AudioSource _hit;   //Audio Source for Hit sound

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        _hit = GetComponent<AudioSource>();
        _tricks = FindObjectOfType<Tricks>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, (inverse) * vertical, 0);
        Vector3 finalDirection = new Vector3(horizontal, (inverse) * vertical, 1.0f);

        transform.position += direction * movementSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection), Mathf.Deg2Rad * rotationSpeed);
    }

    ///<summary>
    ///Collision Detection for Player
    ///</summary>
    ///<param name=”collision”>The collision object the player has collided with</param>
    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;
        if (_tricks.inTrick == false)
        {
            _tricks.inTrick = true;
            if (otherGO.tag == "Enemy")
            {
                _hit.Play();
                Destroy(otherGO);
                HealthManager.Instance.ChangeHealth(-10.0f);
            }
            else if (otherGO.tag == "Terrain")
            {
                _hit.Play();
                HealthManager.Instance.ChangeHealth(-5.0f);
            }
            Invoke("TurnOnCollider", 2.0f);
        }
    }

    /// <summary>
    /// Invinciblity for 2 seconds Once taken damage
    /// </summary>
    void TurnOnCollider()
    {
        _tricks.inTrick = false;
    }
}
