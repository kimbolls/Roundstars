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
    public GameObject quizmenu,pausemenu;
    [SerializeField] 
    public GameObject activemenu;
    private NaviMenu selectedmenu;
    public EnemySpawner spawner;
    public bool paused = false;
    
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
    
    public void OnPaused(InputAction.CallbackContext context){
        //jumped = context.ReadValue<bool>();
        paused = context.action.triggered;
        spawner.PauseGame(paused);
    }
    
    void Start()
    {
        // activemenu = quizmenu;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(activemenu.activeSelf)
        {
            selectedmenu = activemenu.GetComponent<NaviMenu>();
            if(RightInput)
        {

            selectedmenu.moveRight();
        }
        else if(LeftInput)
        {
            selectedmenu.moveLeft();
        }
        else if(DownInput)
        {
            selectedmenu.moveDown();
        }
        else if(UpInput)
        {
            selectedmenu.moveUp();
        }
        }
        
    }

     

}
