using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account_Button : MonoBehaviour
{
    public GameObject Account_screen;
    public GameObject SignUp_screen;
    public GameObject SignIn_screen;
    public GameObject Quit_screen;

    public void SignUp()
    {
        Account_screen.SetActive(false);
        SignUp_screen.SetActive(true);
    }
    public void SignIn()
    {
        Account_screen.SetActive(false);
        SignIn_screen.SetActive(true);
    }
    public void Quit()
    {
        Account_screen.SetActive(false);
        Quit_screen.SetActive(true);
    }
}
