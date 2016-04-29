using UnityEngine;
using System.Collections;

/// <summary>
/// Collecting Rings
/// </summary>
public class Collect : MonoBehaviour
{
    bool _spinning = false;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (!_spinning)
        {
            Vector3 newRotation = transform.localRotation.eulerAngles;
            newRotation.y += 10;
            transform.localRotation = Quaternion.Euler(newRotation);
        }
    }

    ///<summary>
    ///Collision Detection for Player
    ///</summary>
    ///<param name=”collision”>The collision object the player has collided with</param>
    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;
        if (otherGO.tag == "Player")
        {
            GameManager.Instance.AddScore(5);
            Destroy(gameObject);
            //StartCoroutine(Spin());
        }
    }
}
