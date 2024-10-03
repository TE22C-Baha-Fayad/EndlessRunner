using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int Health = 100;
    public static float speed { get; private set; } = 5f;
    [SerializeField] int functionalityDelay = 3;
    [SerializeField] int takeDamageAmmount = 20;
    [SerializeField] float hitCooldownTime = 1f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] LayerMask targetRayLayers;
    [SerializeField] float collisionDistance = 0.5f;


    public delegate void PlayerHit(int ammountSeconds);
    public static event PlayerHit OnPlayerHit;

    public delegate void FunctionalityDelayReport(int ammountSeconds);
    public static event FunctionalityDelayReport OnFunctionalityDelayReport;
    private bool JumpBtnPressed = false;
    Vector2 Playersize;
    Rigidbody2D rb;
    // Start is called before the first frame update
    private void OnEnable()
    {
        DayUiController.OnDayCounterIncrease += DayUiController_OnDayCounterIncrease;
    }

    private void OnDisable()
    {
        DayUiController.OnDayCounterIncrease -= DayUiController_OnDayCounterIncrease;
    }

    private void DayUiController_OnDayCounterIncrease()
    {
        if (speed < 14)
            speed += 0.05f;
    }
    void Start()
    {
        OnFunctionalityDelayReport?.Invoke(functionalityDelay);
        Playersize = GetComponent<SpriteRenderer>().bounds.size;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    bool playerHitFactor = false;
    float hitCooldownTimer = 0;

    float startTimer = 0;
    bool canUpdate = false;
    void Update()
    {   
        if (!canUpdate)
        startTimer += Time.deltaTime;

        if(startTimer > functionalityDelay)
        canUpdate = true;
        
        if(canUpdate)
        HandleUpdateFunctionality();
    }

    void HandleUpdateFunctionality()
    {
        bool IsGrounded()
        {
            RaycastHit2D rayCastHitGround = Physics2D.BoxCast(transform.position, Playersize, 0, Vector2.down, collisionDistance, LayerMask.GetMask("Ground"));
            return rayCastHitGround.collider != null;
        }
        bool HitObstacles()
        {
            RaycastHit2D rayCastHitObstacles = Physics2D.BoxCast(transform.position, Playersize, 0, Vector2.down, 0.1f, LayerMask.GetMask("Obstacle"));
            return rayCastHitObstacles.collider != null;
        }


        if (HitObstacles() && !playerHitFactor)
        {
            playerHitFactor = true;
            rb.velocity = new Vector2(rb.velocity.x, 5f);
            Health -= takeDamageAmmount;
            OnPlayerHit?.Invoke(takeDamageAmmount);
            if (Health <= 0) Destroy(this.gameObject);
        }

        if (playerHitFactor)
        {
            hitCooldownTimer += Time.deltaTime;
            if (hitCooldownTimer > hitCooldownTime)
            {
                playerHitFactor = false;
                hitCooldownTimer = 0;
            }
        }



        float jumpVelocity = Mathf.Sqrt(2 * 9.82f * rb.gravityScale * jumpHeight);
        float fullJumpTime = jumpHeight / jumpVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            JumpBtnPressed = true;
        }
        if (!IsGrounded() && JumpBtnPressed)
        {
            transform.Rotate(Vector3.back * (90 / fullJumpTime) * Time.deltaTime);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        if (rb.velocity.x < 0)
            rb.velocity = new Vector2(0, rb.velocity.y);
        Vector3 cameraPosition = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(transform.position.x, cameraPosition.y, cameraPosition.z);

    }
}
