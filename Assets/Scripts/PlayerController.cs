using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void Update()
    {
        PlayerDirection();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.right * m_MoveSpeed * Time.fixedDeltaTime);
        }
    }

    private void PlayerDirection()
    {
        Vector2 dir = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
