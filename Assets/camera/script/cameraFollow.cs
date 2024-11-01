using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private float followSpeed = 2f;
    [SerializeField] private GameObject player;
    private Transform target;

    public void SetCameraTarget()
    {
        player = GameObject.FindGameObjectWithTag("PlayerGaming");
        target = player.transform;
    }
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    void LateUpdate()
    {

    }

    private void FixedUpdate()
    {

    }
}
