using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    void OnBecameInvisible()
    {
        Debug.Log("destroy");
        Destroy(gameObject);
    }
}
