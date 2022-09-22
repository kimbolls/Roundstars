using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaviMenu : MonoBehaviour
{
    public Master_Navigator masternavi;

    [SerializeField]
    private GameObject[] buttonlist;
    [SerializeField]
    private int i = 0;
    public GameObject selected;
    [SerializeField]
    private float pauseTimer;
    public EnemySpawner enemyspawner;
    
    public GameObject activeButton;
    public GameObject thisMenu;
    public GameObject QuizMenu;
    public GameObject PauseMenu;
    //public Button activeButton;
    
    public  List<int> maxleft = new List<int>();
    public  List<int> maxRight = new List<int>();
    public  List<int> maxUp = new List<int>();
    public  List<int> maxDown = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        masternavi = GameObject.Find("Player 2").GetComponent<Master_Navigator>();
        enemyspawner = GameObject.Find("GameMaster").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        selected = buttonlist[i];
        if(thisMenu == QuizMenu)
        {
            QuizMenuActive();
        }
        else if(thisMenu == PauseMenu)
        {
            PauseMenuActive();
        }
    }

    public void PauseMenuActive()
    {
        activeButton = selected;
        selectedButton(selected);
    }
    public void QuizMenuActive()
    {
            
        activeButton = selected.transform.GetChild(2).gameObject;   //get child 3 means = P2 button
        selectedAnswer(selected);
        pauseTimer -= Time.unscaledDeltaTime;
        if(pauseTimer <= 0f)
        {
            pauseTimer = 0f;
            Time.timeScale = 1f;
            thisMenu.SetActive(false);
        }
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
    public void selectedAnswer(GameObject selected)
    {
        activeButton.SetActive(true);
    }
    public void  moveRight()
    {

        if(!maxRight.Contains(i))
        {
            if(thisMenu == QuizMenu)
            activeButton.SetActive(false);
            i++;
        }
        masternavi.RightInput = false;
        Debug.Log("right");
    }

    public void moveLeft()
    {
        if(!maxleft.Contains(i))
        {
            if(thisMenu == QuizMenu)
            activeButton.SetActive(false);
            i--;
        }
        masternavi.LeftInput = false;
        Debug.Log("left");
    }
    public void moveUp()
    {
        if(!maxUp.Contains(i))
        {
            if(thisMenu == QuizMenu)
            activeButton.SetActive(false);
            i = i -2;
        }
        masternavi.UpInput = false;
        Debug.Log("up");
    }
    public void moveDown()
    {

        if(!maxDown.Contains(i))
        {
            if(thisMenu == QuizMenu)
            activeButton.SetActive(false);
            i = i + 2;
        }
        masternavi.DownInput = false;
        Debug.Log("down");
    }   
}
