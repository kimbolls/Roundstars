using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
public class mainmenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject SettingsMenu;
    public GameObject Customizechar;
    public TMP_Dropdown[] dropdown;
    // public int test;
    public GameObject playmenu;

    public GameObject LoadingMenu;
    public Slider loadingSlider;
    public Slider VolumeSlider;
    public AudioMixer audioMixer;

    public AudioSource hoverSound;
    public AudioSource clickSound;

    public ReadDatabase readDB;
    //public GameObject QuitConfirm;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
         LoadVolume();
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
        // StartCoroutine(LoadAsynchronously(1));
    }
    public void PlaySingleplayer()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(3);
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
        LoadVolume();
        dropdown[0].value = PlayerPrefs.GetInt("QuestionType");
        dropdown[1].value = PlayerPrefs.GetInt("GameTimer");
        dropdown[2].value = PlayerPrefs.GetInt("BraceTimer");
        readDB.countQuestions();

    }

    public void SetQuestionType(int i)
    {
        PlayerPrefs.SetInt("QuestionType", dropdown[0].value);
    }

    public void SetGameTimer(int i)
    {
        PlayerPrefs.SetInt("GameTimer", dropdown[1].value);
    }

    public void SetBraceTimer(int i)
    {
        PlayerPrefs.SetInt("BraceTimer", dropdown[2].value);
    }



    public void backtoMenu()
    {
        if (SettingsMenu.active)
        {
            SettingsMenu.SetActive(false);
        }
        else if (playmenu.active)
        {
            playmenu.SetActive(false);
        }
        mainMenu.SetActive(true);

    }
    public void QuitGame() { Application.Quit(); }

    public void LoadVolume()
    {
        if (!PlayerPrefs.HasKey("MasterVolume"))
            PlayerPrefs.SetFloat("MasterVolume", -10);
        VolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }

    public void SetVolume()
    {

        // audioMixer.volume = VolumeSlider.value();
        audioMixer.SetFloat("volume", VolumeSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", VolumeSlider.value);

    }

    public void HoverAction()
    {
        hoverSound.Play();
    }

    public void ClickAction()
    {
        clickSound.Play();
    }

    // IEnumerator LoadAsynchronously(int sceneIndex)
    // {
    //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

    //     LoadingMenu.SetActive(true);
    //     while (!operation.isDone)
    //     {
    //         float progress = Mathf.Clamp01(operation.progress / .9f);
    //         loadingSlider.value = progress;

    //         yield return null;
    //     }
    // }
}
