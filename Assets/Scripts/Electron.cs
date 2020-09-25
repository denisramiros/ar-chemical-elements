using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public float speed;

    Vector3 axis;

    void Start()
    {
        axis = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    void Update()
    {
        transform.RotateAround(transform.parent.position, axis, speed * Time.deltaTime);
    }
}
