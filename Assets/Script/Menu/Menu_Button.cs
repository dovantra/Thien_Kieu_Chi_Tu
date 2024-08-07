using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button : MonoBehaviour
{
    public GameObject Account_screen;
    public GameObject Menu_screen;
    public GameObject Levels_screen;
    public GameObject Shop_screen;
    public GameObject Setting_screen;
    public GameObject Introduce_screen;
    public int Scene_Play;
    
    public void Play_Button()
    {
        SceneManager.LoadScene(Scene_Play);
    }
    public void Levels()
    {
        Menu_screen.SetActive(false);
        Levels_screen.SetActive(true);
    }
    public void Shop()
    {
        Menu_screen.SetActive(false);
        Shop_screen.SetActive(true);
    }
    public void Setting()
    {
        Menu_screen.SetActive(false);
        Setting_screen.SetActive(true);
    }
    public void Introduce()
    {
        Menu_screen.SetActive(false);
        Introduce_screen.SetActive(true);
    }
    public void Back()
    {
        Menu_screen.SetActive(false);
        Account_screen.SetActive(true);
    }
}
