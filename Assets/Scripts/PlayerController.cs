using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    private PlayerPickup m_PlayerPickup;
    private SpriteRenderer m_SpriteRenderer;
    private Color m_PlayerColor;
    private bool m_IsCloaked;
    private void Start()
    {
        m_PlayerPickup = GetComponent<PlayerPickup>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_PlayerColor = m_SpriteRenderer.color;
    }
    private void FixedUpdate()
    {
        float dis = GetDistance();

        if (!m_PlayerPickup.PickingUp && !m_IsCloaked && dis > 0.15f)
        {
           PlayerMovement();
        }
    }

    private void Update()
    {
       
        PlayerDirection();
        Cloak();
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

    private void Cloak()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_PlayerColor.a = 0.3f;
            m_SpriteRenderer.color = m_PlayerColor;
            m_IsCloaked = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            m_PlayerColor.a = 1f;
            m_SpriteRenderer.color = m_PlayerColor;
            m_IsCloaked = false;
        }
    }

    private float GetDistance()
    {
        float distance = Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        return distance;
    }
}
