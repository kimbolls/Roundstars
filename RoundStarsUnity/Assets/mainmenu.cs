using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject SettingsMenu;
    public GameObject Customizechar;

    //public GameObject QuitConfirm;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Customize()
    {
        Customizechar.SetActive(true);
        mainMenu.SetActive(false);
    }
}
