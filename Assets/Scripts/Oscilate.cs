using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Oscaillates a nucelus element. Position is relative to parent.
/// </summary>
public class Oscilate : MonoBehaviour
{
    public float speed;
    [Tooltip("How far from starting point to oscilate")]
    public float amplitude;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = targetPosition = transform.localPosition;
    }

    void Update()
    {
        if (transform.localPosition == targetPosition)
        {
            targetPosition = new Vector3(startPosition.x + Random.Range(-amplitude, amplitude), startPosition.y + Random.Range(-amplitude, amplitude), startPosition.z + Random.Range(-amplitude, amplitude));
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
}
