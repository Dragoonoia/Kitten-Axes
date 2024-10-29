using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3 (0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform target;
        void Update()
    {
        Vector3 targetposition = transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothTime);
    }

    void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
