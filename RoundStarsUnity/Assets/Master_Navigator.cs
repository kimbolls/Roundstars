using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Master_Navigator : MonoBehaviour
{

    //public GameObject[] menuID;
    
    [SerializeField]
    private Vector2 NaviInput = Vector2.zero;
    [SerializeField]
    private NaviMenu quizmenu,pausemenu;
    private NaviMenu activemenu;
    
    public bool LeftInput = false,RightInput= false,DownInput= false,UpInput = false;

    public void Onleft(InputAction.CallbackContext context){
        //jumped = context.ReadValue<bool>();
        LeftInput = context.action.triggered;
    }
    public void Onright(InputAction.CallbackContext context){
        //jumped = context.ReadValue<bool>();
        RightInput = context.action.triggered;
    }
    public void Ondown(InputAction.CallbackContext context){
        //jumped = context.ReadValue<bool>();
        DownInput = context.action.triggered;
    }
    public void Onup(InputAction.CallbackContext context){
        //jumped = context.ReadValue<bool>();
        UpInput = context.action.triggered;
    }
    // Start is called before the first frame update
    void Start()
    {
        activemenu = quizmenu;
    }

    // Update is called once per frame
    void Update()
    {
        if(RightInput)
        {
            activemenu.moveRight();
        }
        else if(LeftInput)
        {
            activemenu.moveLeft();
        }
        else if(DownInput)
        {
            activemenu.moveDown();
        }
        else if(UpInput)
        {
            activemenu.moveUp();
        }
    }

     

}
