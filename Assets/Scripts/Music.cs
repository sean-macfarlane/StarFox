using UnityEngine;
using System.Collections;
/// <summary>
/// Singleton Music Player
/// </summary>
public class Music : MonoBehaviour {

    public static Music instance;
    /// <summary>
    /// Use this for initialization
    /// </summary>
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
}
