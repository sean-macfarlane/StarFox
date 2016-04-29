using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the GamePlane
/// </summary>
public class MoveFoward : MonoBehaviour
{

    public float speed = 50.0f; //Speed of Gameplane

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
