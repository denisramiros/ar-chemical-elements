using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public float speed;

    Vector3 axis;
    private void Start()
    {
        transform.LookAt(transform.parent.position);
        axis = Random.Range(0, 2) == 0 ? transform.right : transform.up;
    }

    void Update()
    {
        transform.RotateAround(transform.parent.position, axis, speed * Time.deltaTime);
    }
}
