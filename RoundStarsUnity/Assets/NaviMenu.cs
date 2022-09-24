using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NaviMenu : MonoBehaviour
{
    // public Master_Navigator masternavi;


    public GameObject[] buttonlist;
    private int i = 0;
    public GameObject selected;
    [SerializeField]
    private float pauseTimer;
    
    public EventSystem eventsystem;
    public EnemySpawner enemyspawner;
    
    public GameObject activeButton;
    public GameObject thisMenu;
    public GameObject QuizMenu;
    public GameObject PauseMenu;
    public enum answerEnum{A,B,C,D};
    public bool playerID;
    answerEnum P1_answer = answerEnum.A;
    answerEnum P2_answer = answerEnum.A;
    //public Button activeButton;
    
    // public  List<int> maxleft = new List<int>();
    // public  List<int> maxRight = new List<int>();
    // public  List<int> maxUp = new List<int>();
    // public  List<int> maxDown = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        // masternavi = GameObject.Find("Player 2").GetComponent<Master_Navigator>();
        enemyspawner = GameObject.Find("GameMaster").GetComponent<EnemySpawner>();
        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        // eventsystem.SetSelectedGameObject(buttonlist[0]);
    }

    // Update is called once per frame
    void Update()
    {
        selected = buttonlist[i];
        
    }

    public void OnResume()
    {
        enemyspawner.phase = EnemySpawner.PhaseEnum.Game;
        Time.timeScale = 1f;
        thisMenu.SetActive(false);

    }

    public void OnMenu()
    {

    }

    public void OnQuit()
    {

    }

    public void selectedButton(GameObject selected)
    {
        Button btn = selected.GetComponent<Button>();
        
    }
  
    public void selectA(){
        P1_answer = answerEnum.A;
        disableButton(0);
    }
    public void selectB(){
        P1_answer = answerEnum.B;
        disableButton(1);
    }
    public void selectC(){
        P1_answer = answerEnum.C;
        disableButton(2);
    }
    public void selectD(){
        P1_answer = answerEnum.D;
        disableButton(3);
    }

    void disableButton(int i)
    {
        for(int x = 0; x < buttonlist.Length; x ++)
        {
            if(x != i)
            {
                Button btn = buttonlist[x].GetComponent<Button>();
                btn.interactable = false;
            }
        }
    }
    // public void  moveRight()
    // {

    //     if(!maxRight.Contains(i))
    //     {
    //         if(thisMenu == QuizMenu)
    //         activeButton.SetActive(false);
    //         i++;
    //     }
    //     masternavi.RightInput = false;
    //     Debug.Log("right");
    // }

    // public void moveLeft()
    // {
    //     if(!maxleft.Contains(i))
    //     {
    //         if(thisMenu == QuizMenu)
    //         activeButton.SetActive(false);
    //         i--;
    //     }
    //     masternavi.LeftInput = false;
    //     Debug.Log("left");
    // }
    // public void moveUp()
    // {
    //     if(!maxUp.Contains(i))
    //     {
    //         if(thisMenu == QuizMenu)
    //         activeButton.SetActive(false);
    //         i = i -2;
    //     }
    //     masternavi.UpInput = false;
    //     Debug.Log("up");
    // }
    // public void moveDown()
    // {

    //     if(!maxDown.Contains(i))
    //     {
    //         if(thisMenu == QuizMenu)
    //         activeButton.SetActive(false);
    //         i = i + 2;
    //     }
    //     masternavi.DownInput = false;
    //     Debug.Log("down");
    // }   
}
