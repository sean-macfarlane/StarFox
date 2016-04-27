using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public int inverse = 1;
    public float _rotationSpeed = 50.0f;

    // Use this for initialization
    void Start()
    {

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
}
