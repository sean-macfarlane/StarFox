using UnityEngine;
using System.Collections;

/// <summary>
/// Object Spawner
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject[] spawnObject;    //Object to spawn
    public float xRange = 1.0f; //X range to spawn
    public float yRange = 1.0f; // Y Range to Spawn
    public float minSpawnTime = 1.0f;   //Minimum spawn time
    public float maxSpawnTime = 10.0f;  //Maximum Spawn Time

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime));
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Spawns new Object
    /// </summary>
    void SpawnObject()
    {
        float xOffset = Random.Range(-xRange, xRange);
        float yOffset = Random.Range(-yRange, yRange);
        int spawnObjectIndex = Random.Range(0, spawnObject.Length);
        Instantiate(spawnObject[spawnObjectIndex], transform.position + new Vector3(xOffset, yOffset, 0), spawnObject[spawnObjectIndex].transform.rotation);
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
