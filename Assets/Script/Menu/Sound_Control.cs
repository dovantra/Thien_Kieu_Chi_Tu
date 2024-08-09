using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Control : MonoBehaviour
{
    public AudioSource sfx;

    public void Button_sound()
    {
        sfx.Play();
    }
}
