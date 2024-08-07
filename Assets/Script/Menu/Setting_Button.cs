using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_Button : MonoBehaviour
{
    public GameObject Menu_screen;
    public GameObject Setting_screen;

    public void Back()
    {
        Setting_screen.SetActive(false);
        Menu_screen.SetActive(true);
    }
}
