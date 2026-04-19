using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The object the camera will follow
    public Vector3 offset; // The offset from the target position
    public float followSpeed = 5f; // The speed at which the camera follows the target
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
