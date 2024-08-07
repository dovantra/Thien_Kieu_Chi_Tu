using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Button : MonoBehaviour
{
    public GameObject Menu_screen;
    public GameObject Shop_screen;

    public void Back()
    {
        Shop_screen.SetActive(false);
        Menu_screen.SetActive(true);
    }
}
