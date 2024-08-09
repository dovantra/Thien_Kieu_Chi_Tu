using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduce_Button : MonoBehaviour
{
    public GameObject Introduce_screen;
    public GameObject Menu_screen;

    public void Back()
    {
        Introduce_screen.SetActive(false);
        Menu_screen.SetActive(true);
    }
}
