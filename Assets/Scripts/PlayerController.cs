using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [Range(0, 100)] private float Health = 100f;
    [SerializeField] float speed = 1f;
    [SerializeField] float takeDamageAmmount = 20;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] LayerMask targetRayLayers;
    [SerializeField] float collisionDistance = 0.5f;

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
        Playersize = GetComponent<SpriteRenderer>().bounds.size;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        bool IsGrounded()
        {
            RaycastHit2D rayCastHitGround = Physics2D.BoxCast(transform.position, Playersize, 0, Vector2.down, collisionDistance, LayerMask.GetMask("Ground"));
            return rayCastHitGround.collider != null;
        }
        bool HitObstacles()
        {
            RaycastHit2D rayCastHitObstacles = Physics2D.BoxCast(transform.position, Playersize, 0, Vector2.down, collisionDistance, LayerMask.GetMask("Obstacles"));
            return rayCastHitObstacles.collider != null;
        }
        if (HitObstacles())
        {

            rb.velocity = new Vector2(rb.velocity.x+2, 12f);
            Health -= takeDamageAmmount;
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
