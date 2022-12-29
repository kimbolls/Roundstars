using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialmenu : MonoBehaviour
{


    [SerializeField] private GameObject[] Menus;
    [SerializeField] private GameObject Active_Menu;
    [SerializeField] private GameObject Main_Menu;
    // Start is called before the first frame update
    void Start()
    {
        Active_Menu = Main_Menu;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void menu_Main(int menu_index)
    {
        Active_Menu.SetActive(false);
        Active_Menu = Menus[menu_index];
        Active_Menu.SetActive(true);
    }

    public void back_button()
    {
        Active_Menu.SetActive(false);
        Active_Menu = Main_Menu;
        Active_Menu.SetActive(true);
    }

    public void menu_Basics(int i)
    {

    }
    public void menu_Abilities() { }
    public void menu_Obj1() { }
    public void menu_Obj2() { }

}
