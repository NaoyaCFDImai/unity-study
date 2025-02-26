using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropControl : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    GameObject _gameObject;
    Camera _camera;
    private float _zDistance;

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _gameObject = this.gameObject;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        float x = eventData.position.x;
        float y = eventData.position.y;
        _zDistance = _camera.WorldToScreenPoint(_gameObject.transform.position).z;
        Debug.Log($"(x, y) = ({x}, {y})");
        Vector3 screenPoint = new Vector3(x, y, 0);
        Debug.Log($"Screen Point: {screenPoint}");
        Vector3 viewportPoint = _camera.ScreenToViewportPoint(screenPoint);
        Debug.Log($"Viewport Point: {viewportPoint}");
        Vector3 worldPoint = _camera.ViewportToWorldPoint(viewportPoint);
        Debug.Log($"World Point: {worldPoint}");

    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            return;
        }

        float x = eventData.position.x;
        float y = eventData.position.y;
        Vector3 screenPoint = new Vector3(x, y, _zDistance);
        Debug.Log($"Screen Point: {screenPoint}");
        Vector3 viewportPoint = _camera.ScreenToViewportPoint(screenPoint);
        Debug.Log($"Viewport Point: {viewportPoint}");
        Vector3 worldPoint = _camera.ViewportToWorldPoint(viewportPoint);
        Debug.Log($"World Point: {worldPoint}");
        _gameObject.transform.position = worldPoint;
    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
