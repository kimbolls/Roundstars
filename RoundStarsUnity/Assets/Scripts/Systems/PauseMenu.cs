using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] buttonlist;
    public GameObject selected;
    public EventSystem eventsystem;
    public EnemySpawner enemyspawner;
    // Start is called before the first frame update
    void Start()
    {
        eventsystem.SetSelectedGameObject(buttonlist[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnResume()
    {
        enemyspawner.ResumeGame();
    }

    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }
    void OnQuit() { Application.Quit(); }
}
