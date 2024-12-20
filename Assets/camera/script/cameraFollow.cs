using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private float followSpeed = 4f;
    [SerializeField] private GameObject player;
    private Transform target;

    public void SetCameraTarget(Transform abacate)
    {
        player = abacate.gameObject;
        target = player.transform;
    }
    void Update()
    {
        if (player != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y+2, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }

    void LateUpdate()
    {

    }

    private void FixedUpdate()
    {

    }
}
