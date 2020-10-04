using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : MonoBehaviour
{
    public Element ElementToPlace { get; set; }

    private ARRaycastManager _mRaycastManager;
    private readonly List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private GameObject spawnedObject;

    private void Awake()
    {
        _mRaycastManager = GetComponent<ARRaycastManager>();
    }

    private static bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            return true;
        }
#else
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out var touchPosition))
            return;

        if (_mRaycastManager.Raycast(touchPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one will be the closest hit.
            var hitPose = _hits[0].pose;
            Debug.Log("Okay");
        
            if (spawnedObject == null)
            {
                GameObject.Find("ElementSpawner").GetComponent<ChemicalElementSpawner>().Spawn(ElementToPlace.number, ElementToPlace.atomic_mass, ElementToPlace.electron_configuration);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }
}
