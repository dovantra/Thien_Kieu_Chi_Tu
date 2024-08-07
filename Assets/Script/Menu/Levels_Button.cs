using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels_Button : MonoBehaviour
{
    public GameObject Menu_screen;
    public GameObject Levels_screen;

    public void Back()
    {
        Levels_screen.SetActive(false);
        Menu_screen.SetActive(true);
    }
}
