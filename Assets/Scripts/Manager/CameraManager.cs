using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Properties")]
    public Transform player;
    [Space]
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
