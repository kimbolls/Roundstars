using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P1_Movement : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public P1_Aiming aiming;

    public int MaxJumpCharge;
    public int CurrentJumpCharge;

    [SerializeField]
    private Vector2 movementInput = Vector2.zero;
    public bool jumped = false;

    // public float facingDirection;
    public float lookingDirection;
    //dashing

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.15f;
    public float dashingCooldown;
    public float dashingtimer;

    public bool dashed = false;
    public AudioSource dash_sound;
    // private float horizontal;
    // private bool isFacingRight = true;

    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentJumpCharge = MaxJumpCharge;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //jumped = context.ReadValue<bool>();
        jumped = context.action.triggered;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        dashed = context.action.triggered;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        Move();
        Jump();
        if (dashed && canDash)
        {
            StartCoroutine(Dash());

        }

        if (dashingtimer >= 0)
        {
            dashingtimer -= Time.deltaTime;
        }

        // facingDirection = transform.eulerAngles.y;
        // lookingDirection = transform.eulerAngles.y;
        // lookingDirection = 180;
    }



    void Move()
    {
        float x = movementInput.x;
        // float x = movementInput.x;  //get input from user, horizontals
        float moveBy = x * speed;  // multiply the input with speed 
        rb.velocity = new Vector2(moveBy, rb.velocity.y);  // set velocity of player with the moveBy variable
    }

    void Jump()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     jumped = true;
        // }
        // else
        // {
        //     jumped = false;
        // }
        if (jumped && CurrentJumpCharge != 0 && Time.timeScale != 0f) // allow user to jump when space is inputted, prevents jumping when no stamina
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // set velocity with jumpforce
            CurrentJumpCharge -= 1;
            if (CurrentJumpCharge <= 0) { CurrentJumpCharge = 0; }
            jumped = false;


        }
        BetterJump();


    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {

            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && jumped)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.tag != "bullets")
        {
            CurrentJumpCharge = MaxJumpCharge;
        }
    }

    public void RotatePlayer0()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void RotatePlayer180()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, lookingDirection, 0));
    }

    // private void Flip()
    // {
    //     if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
    //     {
    //         Vector3 localscale = transform.localScale;
    //         isFacingRight = !isFacingRight;
    //         localscale.x *= 1f;
    //         transform.localScale = localscale;
    //     }
    // }

    private IEnumerator Dash()
    {
        dashingtimer = dashingCooldown;
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        if (aiming.angle < -90 || aiming.angle > 90)
        { rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f); }
        else { rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f); }
        tr.emitting = true;
        dash_sound.Play();
        
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
