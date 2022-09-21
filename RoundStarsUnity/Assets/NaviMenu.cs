using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviMenu : MonoBehaviour
{
    public Master_Navigator masternavi;
    // Start is called before the first frame update
    void Start()
    {
        masternavi = GameObject.Find("Player 2").GetComponent<Master_Navigator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  moveRight()
    {
        masternavi.RightInput = false;
        Debug.Log("right");
    }

    public void moveLeft()
    {
        masternavi.LeftInput = false;
        Debug.Log("left");
    }
    public void moveUp()
    {
        masternavi.UpInput = false;
        Debug.Log("up");
    }
    public void moveDown()
    {
        masternavi.DownInput = false;
        Debug.Log("down");
    }   
}
