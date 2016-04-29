using UnityEngine;
using System.Collections;

/// <summary>
/// Player Tricks
/// </summary>
public class Tricks : MonoBehaviour
{
    public float barrelRollDuration = 0.5f; // Duration of a Barrel Roll
    public bool inTrick = false;    // If the Player is currently doing a trick

    /// <summary>
    ///  Update is called once per frame
    /// </summary>
    void Update()
    {
        if (!inTrick)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    StartCoroutine(BarrelRoll(false));
                }
                else
                {
                    StartCoroutine(BarrelRoll(true));
                }
            }
        }
    }

    /// <summary>
    /// To do a Barrel Roll
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    IEnumerator BarrelRoll(bool direction)
    {
        inTrick = true;
        float t = 0.0f;
        int invert = 1;
        if (direction == false)
        {
            invert = -1;
        }

        Vector3 initialRotation = transform.localRotation.eulerAngles;
        Vector3 goalRotation = initialRotation;
        goalRotation.z += 360.0f * invert;

        Vector3 currentRotation = initialRotation;

        while (t < barrelRollDuration)
        {
            currentRotation.z = Mathf.Lerp(initialRotation.z, goalRotation.z, t / barrelRollDuration);
            transform.localRotation = Quaternion.Euler(currentRotation);
            t += Time.deltaTime;
            yield return null;
        }

        inTrick = false;
    }
}
