using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	/// <summary>
    /// Rotates Y
    /// </summary>
	void Update () {
        transform.Rotate(new Vector3(0, 45)*Time.deltaTime); 
	}
}
