using UnityEngine;

/// <summary>
/// Oscaillates a nucelus element. Position is relative to parent.
/// </summary>
public class Oscilate : MonoBehaviour
{
    public float speed;
    [Tooltip("How far from starting point to oscilate")]
    public float amplitude;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private void Start()
    {
        _startPosition = _targetPosition = transform.localPosition;
    }

    private void Update()
    {
        if (transform.localPosition == _targetPosition)
        {
            _targetPosition = new Vector3(_startPosition.x + Random.Range(-amplitude, amplitude), _startPosition.y + Random.Range(-amplitude, amplitude), _startPosition.z + Random.Range(-amplitude, amplitude));
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, speed * Time.deltaTime);
        }
    }
}
