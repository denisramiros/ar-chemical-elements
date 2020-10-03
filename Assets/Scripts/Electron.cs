using UnityEngine;

public class Electron : MonoBehaviour
{
    public float speed;

    private Vector3 _axis;
    
    private void Start()
    {
        transform.LookAt(transform.parent.position);
        _axis = Random.Range(0, 2) == 0 ? transform.right : transform.up;
    }

    private void Update()
    {
        transform.RotateAround(transform.parent.position, _axis, speed * Time.deltaTime);
    }
}
