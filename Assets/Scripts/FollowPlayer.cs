using UnityEngine;
using System.Collections;

/// <summary>
/// Camera Follows Player 
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    public Transform objectToFollow;        //Object for Camera to Follow
    public Vector2 movementRatio;   //Ratio for Following the Movement

    /// <summary>
    /// Update is called once per frame
   /// </summary>
    void LateUpdate()
    {
        Vector3 newPosition = objectToFollow.position;
        newPosition.x *= movementRatio.x;
        newPosition.y = (newPosition.y * movementRatio.y) + 5.0f;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
