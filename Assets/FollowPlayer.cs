using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector2 movementRatio;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = objectToFollow.position;
        newPosition.x *= movementRatio.x;
        newPosition.y = (newPosition.y * movementRatio.y) + 5.0f;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
