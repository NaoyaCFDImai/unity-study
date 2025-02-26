using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClicked : MonoBehaviour, IPointerClickHandler
{
    static GameObject _mainCameraGameObject;
    static Camera _mainCamera;

    public void Start()
    {
        _mainCameraGameObject = GameObject.FindGameObjectWithTag("MainCamera");
        _mainCamera = _mainCameraGameObject.GetComponent<Camera>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var gameObject = this.gameObject;
        var test = eventData.pointerCurrentRaycast.worldPosition;
        Debug.Log($"{eventData.ToString()}");
        Debug.Log($"Object Clicked: {gameObject.name}");

        Matrix4x4 worldMatrix = gameObject.transform.localToWorldMatrix;
        Matrix4x4 localMatrix = gameObject.transform.worldToLocalMatrix;
        Vector3 localPoint = new Vector3(0, 0, 0);
        Vector3 worldPoint = transform.localToWorldMatrix.MultiplyPoint(localPoint);

        var meshFilter = gameObject.GetComponent<MeshFilter>();
        if (meshFilter != null && meshFilter.mesh != null)
        {
            var mesh = meshFilter.mesh;
            Vector3[] vertices = mesh.vertices;

            if (vertices.Length > 0)
            {
                Vector3 firstVertex = vertices[0];
                VectorLogger.LogVector(firstVertex, nameof(firstVertex));
                var worldP = worldMatrix.MultiplyPoint(firstVertex);
                VectorLogger.LogVector(worldP, nameof(worldP));
            }
        }

        //Debug.Log($"Local Point: {localPoint}");
        //Debug.Log($"World Point: {worldPoint}");

        //MatrixLogger.LogMatrix(worldMatrix, nameof(worldMatrix));
        //MatrixLogger.LogMatrix(localMatrix, nameof(localMatrix));

        //// print transform position
        //Debug.Log($"Position: {transform.position}");
        //// print transform rotation
        //Debug.Log($"Rotation: {transform.rotation}");
        //// print transform scale
        //Debug.Log($"Scale: {transform.localScale}");


        //Debug.Log($"Right:    {CameraRight}");
        //Debug.Log($"UP:       {CameraUp}");
        //Debug.Log($"Forward:  {CameraForward}");
        //Debug.Log($"Backward: {CameraBackward}");
    }

    public Vector3 CameraRight
    {
        get
        {
            return _mainCamera.transform.right;
        }
    }
    public Vector3 CameraUp
    {
        get
        {
            return _mainCamera.transform.up;
        }
    }
    public Vector3 CameraForward
    {
        get
        {
            return _mainCamera.transform.forward;
        }
    }
    public Vector3 CameraBackward
    {
        get
        {
            return _mainCamera.cameraToWorldMatrix.GetColumn(2);
        }
    }
}

public class MatrixLogger
{
    public static void LogMatrix(Matrix4x4 matrix, string label)
    {
        string formattedMatrix =
            $"{label}:\n" +
            $"{matrix.m00,8:F3} {matrix.m01,8:F3} {matrix.m02,8:F3} {matrix.m03,8:F3}\n" +
            $"{matrix.m10,8:F3} {matrix.m11,8:F3} {matrix.m12,8:F3} {matrix.m13,8:F3}\n" +
            $"{matrix.m20,8:F3} {matrix.m21,8:F3} {matrix.m22,8:F3} {matrix.m23,8:F3}\n" +
            $"{matrix.m30,8:F3} {matrix.m31,8:F3} {matrix.m32,8:F3} {matrix.m33,8:F3}";

        Debug.Log(formattedMatrix);
    }
}

public class VectorLogger
{
    public static void LogVector(Vector3 vector, string label)
    {
        string formattedVector = $"{label}: {vector.x,8:F3}, {vector.y,8:F3}, {vector.z,8:F3}";
        Debug.Log(formattedVector);
    }
}