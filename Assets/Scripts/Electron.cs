using UnityEngine;

public class Electron : MonoBehaviour
{
    public float speed;

    private Vector3 _axis;
    
    private void Start()
    {
        transform.LookAt(transform.parent.position);
        // transform.Rotate(0, 0, Random.Range(0, 180), Space.Self);
        _axis = transform.up;
    }

    private void Update()
    {
        transform.RotateAround(transform.parent.position, _axis, speed * Time.deltaTime);
    }
}
