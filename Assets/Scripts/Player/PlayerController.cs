using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed;

    [Header("Cloak Properties")]
    public float cloakCooldownTime = 5;
    public bool isCloaked;
    [Space]
    public TMP_Text cloakCooldownText;
    public GameObject cloakCooldownTimerUI;
    public GameObject cloakObject;

    private Color cloakColor;
    private float cloakCooldownCounter;
    private bool inCloakCooldown;

    [Header("Takedown Properties")]
    public bool inTakeDownRange;
    private GameObject takeDownTarget;
    public int takeDownsAmount = 1;
    public GameObject takeDownObject;
    public TMP_Text takeDownAmountTxt;
    private Color takeDownColor;

    [Header("Other References")]
    public GameObject gameOverObject;
    public GameObject exitText;
    public PlayerInventory playerInventory;

    private PlayerPickup playerPickUp;
    private SpriteRenderer spriteRenderer;
    private Color playerColor;
    private bool inExitRange;
    public bool IsSeeingPlayer { get; set; }

    private void Start()
    {
        // instantiate
        playerPickUp = GetComponent<PlayerPickup>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //set UI stuff
        cloakColor = cloakObject.GetComponent<Image>().color;
        playerColor = spriteRenderer.color;
        takeDownColor = takeDownObject.GetComponent<Image>().color;
        takeDownAmountTxt.text = ("" + takeDownsAmount);

        // set bools to false
        inCloakCooldown = false;
        inExitRange = false;
        inTakeDownRange = false;

        // set overlays / other stuff to inactive
        gameOverObject.SetActive(false);
        exitText.SetActive(false);
        cloakCooldownTimerUI.SetActive(false);

        // reset timers
        cloakCooldownCounter = cloakCooldownTime;

        moveSpeed = GameRules.Instance.playerMoveSpeed;
    }

    private void FixedUpdate()
    {
        float dis = GetDistance();

        if (!playerPickUp.isPickingUp && !isCloaked && dis > 0.15f)
        {
            PlayerMovement();
        }
    }

    private void Update()
    {
        if (inCloakCooldown)
        {
            int temp = (int)cloakCooldownCounter;
            cloakCooldownText.text = temp.ToString();
            cloakCooldownTimerUI.SetActive(true);
            cloakColor.a = 0.5f;
            cloakObject.GetComponent<Image>().color = cloakColor;

            cloakCooldownCounter -= Time.deltaTime;

            if (cloakCooldownCounter < 0)
            {
                cloakCooldownCounter = cloakCooldownTime;
                cloakCooldownTimerUI.SetActive(false);
                inCloakCooldown = false;
                cloakColor.a = 1f;
                cloakObject.GetComponent<Image>().color = cloakColor;
            }
        }

        if (takeDownsAmount <= 0)
        {
            takeDownColor.a = 0.5f;
            takeDownObject.GetComponent<Image>().color = takeDownColor;
        }

        if (Input.GetKeyDown(KeyCode.T) && inExitRange)
        {
            ConvertToInventory();
            SceneLoader.Instance.LoadScene(2);
        }


        if (Input.GetKeyDown(KeyCode.Q) && inTakeDownRange && !IsSeeingPlayer && takeDownsAmount > 0)
        {
            TakeDown(takeDownTarget);
            takeDownsAmount--;
            takeDownAmountTxt.text = ("" + takeDownsAmount);
        }


        PlayerDirection();
        Cloak();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Exit"))
        {
            exitText.SetActive(true);
            inExitRange = true;
        }

        if (collision.gameObject.CompareTag("Guard"))
        {
            inTakeDownRange = true;
            takeDownTarget = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            exitText.SetActive(false);
            inExitRange = false;
        }

        if (collision.gameObject.CompareTag("Guard"))
        {
            inTakeDownRange = false;
        }
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime);
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
        if (Input.GetKeyDown(KeyCode.E) && !inCloakCooldown)
        {
            playerColor.a = 0.3f;
            spriteRenderer.color = playerColor;
            isCloaked = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            playerColor.a = 1f;
            spriteRenderer.color = playerColor;
            isCloaked = false;
            inCloakCooldown = true;
        }
    }

    private void TakeDown(GameObject target)
    {
        if (target != null)
        {
            target.SetActive(false);
        }
    }

    private float GetDistance()
    {
        float distance = Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        return distance;
    }

    private void ConvertToInventory()
    {
        playerInventory.Diamond += InventoryAdder.instance.grabbedDiamonds;
        playerInventory.Emerald += InventoryAdder.instance.grabbedEmeralds;
        playerInventory.Gold += InventoryAdder.instance.grabbedGold;
        playerInventory.Pearl += InventoryAdder.instance.grabbedPearls;
        playerInventory.Ruby += InventoryAdder.instance.grabbedRubys;
    }
}
