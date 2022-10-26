using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject SettingsMenu;
    public GameObject Customizechar;
    public TMP_Dropdown dropdown;   
    // public int test;
    public GameObject playmenu;
    //public GameObject QuitConfirm;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerPrefs.SetInt("QuestionType",dropdown.value);
        // test = PlayerPrefs.GetInt("QuestionType");
    }
    public void PlayMenu()
    {
        playmenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void PlayMultiplayer()
    {
        SceneManager.LoadScene(1);
    }
    public void PlaySingleplayer()
    {

    }

    public void PlayTutorial()
    {

    }


    public void Customize()
    {
        Customizechar.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        dropdown.value = PlayerPrefs.GetInt("QuestionType");
    }

    public void SetQuestionType(int i)
    {
        PlayerPrefs.SetInt("QuestionType",dropdown.value);
    }

    public void backtoMenu()
    {
        if(SettingsMenu.active)
        {
            SettingsMenu.SetActive(false);
        }
        else if(playmenu.active)
        {
            playmenu.SetActive(false);
        }
        mainMenu.SetActive(true);
        
    }
    public void QuitGame(){}
}
