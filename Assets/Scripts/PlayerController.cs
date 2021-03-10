using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_CloakCooldownTimer = 5;
    [SerializeField] private TextMeshProUGUI m_CloakCooldownText;
    [SerializeField] private GameObject m_CloakImg;
    private PlayerPickup m_PlayerPickup;
    private SpriteRenderer m_SpriteRenderer;
    private Color m_PlayerColor;
    private Color m_CloakColor;
    public bool m_IsCloaked;
    private float m_CloakCooldownCounter;
    private bool m_CloakCooldown;
    private void Start()
    {
        m_PlayerPickup = GetComponent<PlayerPickup>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_CloakColor = m_CloakImg.GetComponent<Image>().color;
        m_PlayerColor = m_SpriteRenderer.color;
        m_CloakCooldown = false;
        m_CloakCooldownCounter = m_CloakCooldownTimer;
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
        if (m_CloakCooldown)
        {
            int temp = (int)m_CloakCooldownCounter;
            m_CloakCooldownText.text = temp.ToString();
            m_CloakCooldownText.gameObject.SetActive(true);
            m_CloakColor.a = 0.5f;
            m_CloakImg.GetComponent<Image>().color = m_CloakColor;
            m_CloakCooldownCounter -= Time.deltaTime;
            if (m_CloakCooldownCounter < 0)
            {
                m_CloakCooldownCounter = m_CloakCooldownTimer;
                m_CloakCooldownText.gameObject.SetActive(false);
                m_CloakCooldown = false;
                m_CloakColor.a = 1f;
                m_CloakImg.GetComponent<Image>().color = m_CloakColor;
            }
        }
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
        if (Input.GetKeyDown(KeyCode.E) && !m_CloakCooldown)
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
            m_CloakCooldown = true;
        }
    }

    private float GetDistance()
    {
        float distance = Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        return distance;
    }
}
