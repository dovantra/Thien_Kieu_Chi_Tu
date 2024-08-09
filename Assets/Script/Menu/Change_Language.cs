using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Language : MonoBehaviour
{
    public GameObject Vietnamese;
    public GameObject English;

    public void Vietnamese_Button()
    {
        Vietnamese.SetActive(true);
        English.SetActive(false);
    }
    public void English_Button()
    {
        English.SetActive(true);
        Vietnamese.SetActive(false);
    }
}
