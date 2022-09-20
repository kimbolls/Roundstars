using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class  Player2_Movement : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public int MaxJumpCharge;
    public int CurrentJumpCharge;
    
    [SerializeField]
    private Vector2 movementInput = Vector2.zero;
    public bool jumped = false;

    public float facingDirection;
    public float lookingDirection;

    //trial
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentJumpCharge = MaxJumpCharge;
    }

    public void OnMove(InputAction.CallbackContext context){
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context){
        //jumped = context.ReadValue<bool>();
        jumped = context.action.triggered;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        facingDirection = transform.eulerAngles.y;
        lookingDirection = transform.eulerAngles.y;
        lookingDirection = 180;
    }

    

    void Move()
    {
        float x = movementInput.x;  //get input from user, horizontals
        float moveBy = x * speed;  // multiply the input with speed 
        rb.velocity = new Vector2(moveBy, rb.velocity.y);  // set velocity of player with the moveBy variable
    }

    void Jump()
    {
        // if(Input.GetKey("rightTrigger"))
        // {
        //     jumped = true;
            
        // }
        // else
        // {
        //     jumped = false;
        // }
        if ( jumped && CurrentJumpCharge != 0 && Time.timeScale != 0f) // allow user to jump when space is inputted, prevents jumping when no stamina
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // set velocity with jumpforce
            CurrentJumpCharge -= 1;
            if(CurrentJumpCharge <= 0){CurrentJumpCharge = 0;}
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
    else if (rb.velocity.y > 0 &&  jumped) 
    {
        rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {   
        if(hitInfo.gameObject.tag != "bullets")
        {
            CurrentJumpCharge = MaxJumpCharge;
        }
    }
    public void RotatePlayer0()
    {
        Debug.Log("Rotate0");
        transform.rotation = Quaternion.Euler(new Vector3(0,0,0)); 
    }
    public void RotatePlayer180()
    {
        Debug.Log("Rotate180");
        transform.rotation = Quaternion.Euler(new Vector3(0,lookingDirection,0)); 
    }
}
