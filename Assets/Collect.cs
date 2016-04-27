using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour
{
    public float spinDuration = 1.0f;
    public float rotation_angle = 0;
    bool _spinning = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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
            StartCoroutine(Spin());
        }
    }

    IEnumerator Spin()
    {
        float t = 0.0f;
        _spinning = true;

        Vector3 initialRotation = transform.localRotation.eulerAngles;
        Vector3 goalRotation = initialRotation;
        goalRotation.x += 720.0f;

        Vector3 currentRotation = initialRotation;

        while (t < spinDuration)
        {
            currentRotation.x = Mathf.Lerp(initialRotation.x, goalRotation.x, t / spinDuration);
            transform.localRotation = Quaternion.Euler(currentRotation);
            t += Time.deltaTime;
            yield return null;
        }

        _spinning = false;
    }
}
