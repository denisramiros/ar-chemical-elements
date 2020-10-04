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
        //transform.Rotate(0,0,Random.Range(0,180),Space.Self);
        axis = transform.up;
    }

    void Update()
    {
        //transform.RotateAround(transform.parent.position, axis, speed * Time.deltaTime);
    }
}
