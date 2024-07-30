using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Button : MonoBehaviour
{
    public GameObject Account_screen;
    public GameObject Quit_screen;

    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        Quit_screen.SetActive(false);
        Account_screen.SetActive(true);
    }
}
