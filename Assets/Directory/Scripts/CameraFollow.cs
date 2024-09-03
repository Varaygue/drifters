using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; 
    public float followSpeed = 5f; 
    public float cursorInfluence = 0.5f;

    void Start()
    {
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, offset.y));
        Vector3 cursorDirection = mouseWorldPosition - player.position;
        targetPosition += cursorDirection * cursorInfluence;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
