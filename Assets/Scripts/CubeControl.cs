using UnityEngine;

public class Sub : MonoBehaviour
{
    private void Start()
    {
        Debug.Log($"GameObject name: {gameObject.name}");
        Debug.Log($"GameObject Instance ID: {gameObject.GetInstanceID()}");
        Debug.Log($"Sub is added.");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
        }
    }
}

public class CubeControl : MonoBehaviour
{
    Sub ReferenceToSubClass;
    void Start()
    {
        Transform transform = gameObject.GetComponent<Transform>();
        if (transform == null)
        {
            Debug.Log("transform is null");
        }
        Debug.Log($"({transform.position.x}, {transform.position.y}, {transform.position.z})");
        Debug.Log($"GameObject name: {gameObject.name}");
        Debug.Log($"GameObject Instance ID: {gameObject.GetInstanceID()}");
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        ReferenceToSubClass = gameObject.AddComponent<Sub>();
    }
    void Update()
    {
        if (ReferenceToSubClass == null)
        {
            Debug.Log($"Sub is already destroy");
            return;
        }
    }
}
