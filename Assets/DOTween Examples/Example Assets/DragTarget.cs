using UnityEngine;
using System.Collections;

public class DragTarget : MonoBehaviour
{
    private Transform t;
    private Camera mainCam;
    private Vector3 offset;

    private void Start()
    {
        t = transform;
        mainCam = Camera.main;
    }

    private void OnMouseDown()
    {
        Vector2 mousePos = Input.mousePosition;
        float distance = mainCam.WorldToScreenPoint(t.position).z;
        Vector3 worldPos = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance));
        offset = t.position - worldPos;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Input.mousePosition;
        float distance = mainCam.WorldToScreenPoint(t.position).z;
        t.position = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance)) + offset;
    }
}