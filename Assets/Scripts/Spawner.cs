using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject[] spawnObject;
    public Vector2 positionRange = Vector2.one;
    public float xRange = 1.0f;
    public float yRange = 1.0f;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 10.0f;

    // Use this for initialization
    void Start()
    {
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObject()
    {
        float xOffset = Random.Range(-xRange, xRange);
        float yOffset = Random.Range(-yRange, yRange);
        int spawnObjectIndex = Random.Range(0, spawnObject.Length);
        Instantiate(spawnObject[spawnObjectIndex], transform.position + new Vector3(xOffset, yOffset, 0), spawnObject[spawnObjectIndex].transform.rotation);
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
