using UnityEngine;
using System.Collections;

public class Tricks : MonoBehaviour
{ 
    public float barrelRollDuration = 0.5f;

    public bool inTrick = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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
