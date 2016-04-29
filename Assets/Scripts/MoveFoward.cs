﻿using UnityEngine;
using System.Collections;

public class MoveFoward : MonoBehaviour
{

    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
