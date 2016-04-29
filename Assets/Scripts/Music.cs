using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

    public static Music instance;

    // Use this for initialization
    void Start () {
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
