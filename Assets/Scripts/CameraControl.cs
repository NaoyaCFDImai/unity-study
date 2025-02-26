using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Camera _mainCamera { get; set; }
    private float RollSensitive = 10.0f;
    private float ZoomSensitive = 20.0f;
    private float minDistance = 1.0f;
    private float maxDistance = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = GetComponent<Camera>();
        Debug.Log($"CameraControl start");
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Debug.Log($"Scroll: {scroll}");

            Vector3 direction = _mainCamera.transform.forward;
            Vector3 newPosition = _mainCamera.transform.position + direction * scroll * ZoomSensitive;

            float distance = Vector3.Distance(newPosition, transform.position);
            Debug.Log($"Distance: {distance}");
            if (distance > minDistance && distance < maxDistance)
            {
                _mainCamera.transform.position = newPosition;
            }

        }
    }
}
